using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LayananService_C9
{
    public partial class FormPemesananLayanan : Form
    {
        public FormPemesananLayanan()
        {
            InitializeComponent();
            SetupUI();
        }
         
        private void FormPemesananLayanan_Load(object sender, EventArgs e)
        {
            TampilkanPelanggan();
            TampilkanLayanan();
            TampilkanDataPemesanan();
        }

        private void SetupUI()
        {
            // Background image
            PictureBox background = new PictureBox();
            background.Dock = DockStyle.Fill;
            background.Image = Image.FromFile("D:\\Penyimpanan Utama\\Download\\otomotif.jpg");
            background.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(background);

            // Label judul
            Label lblTitle = new Label();
            lblTitle.Text = "Form PemesananLayanan";
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold); // Ukuran lebih kecil dari sebelumnya (18 → 14)
            lblTitle.ForeColor = Color.White;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 20); // Sedikit geser agar tidak menimpa form field

            background.Controls.Add(lblTitle);
        }

        void TampilkanPelanggan()
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Pelanggan, Nama_Pelanggan FROM Pelanggan", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbPelanggan.DataSource = dt;
                cmbPelanggan.DisplayMember = "Nama_Pelanggan";
                cmbPelanggan.ValueMember = "ID_Pelanggan";
                cmbPelanggan.SelectedIndex = -1;
            }
        }

        void TampilkanLayanan()
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Layanan, Nama_Layanan FROM Layanan", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbLayanan.DataSource = dt;
                cmbLayanan.DisplayMember = "Nama_Layanan";
                cmbLayanan.ValueMember = "ID_Layanan";
                cmbLayanan.SelectedIndex = -1;
            }
        }

        void TampilkanDataPemesanan()
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT pl.ID_Pemesanan, 
                     p.Nama_Pelanggan, 
                     p.Poin_Loyalitas,
                     l.Nama_Layanan, 
                     pl.Tanggal_Pemesanan, 
                     pl.Jumlah_Layanan, 
                     pl.Total_Biaya, 
                     pl.Status_Pembayaran
              FROM PemesananLayanan pl
              JOIN Pelanggan p ON p.ID_Pelanggan = pl.ID_Pelanggan
              JOIN Layanan l ON l.ID_Layanan = pl.ID_Layanan", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPemesanan.DataSource = dt;
            }
        }

        void BersihkanForm()
        {
            txtIDPemesanan.Clear();
            cmbPelanggan.SelectedIndex = -1;
            cmbLayanan.SelectedIndex = -1;
            dtpTanggal.Value = DateTime.Now;
            dgvPemesanan.ClearSelection();
        }


        decimal HitungTotalBiaya(int idLayanan, int jumlah)
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Harga FROM Layanan WHERE ID_Layanan = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", idLayanan);
                object result = cmd.ExecuteScalar();
                decimal harga = result != null ? Convert.ToDecimal(result) : 0;
                return harga * jumlah;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbPelanggan.SelectedValue == null || cmbLayanan.SelectedValue == null)
            {
                MessageBox.Show("Pilih pelanggan dan layanan terlebih dahulu.");
                return;
            }

            int idPelanggan = Convert.ToInt32(cmbPelanggan.SelectedValue);
            int idLayanan = Convert.ToInt32(cmbLayanan.SelectedValue);
            int jumlah = 1;
            decimal total = HitungTotalBiaya(idLayanan, jumlah);
            DateTime tanggal = dtpTanggal.Value;

            string status;
            try
            {
                if (cmbKategori.SelectedItem == null)
                    throw new Exception("Status pembayaran belum dipilih.");

                status = cmbKategori.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan input status pembayaran: " + ex.Message);
                return;
            }

            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO PemesananLayanan 
                             (ID_Pelanggan, ID_Layanan, Tanggal_Pemesanan, Jumlah_Layanan, Total_Biaya, Status_Pembayaran)
                             VALUES (@P, @L, @Tgl, @Jml, @Tot, @Status)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@P", idPelanggan);
                    cmd.Parameters.AddWithValue("@L", idLayanan);
                    cmd.Parameters.AddWithValue("@Tgl", tanggal);
                    cmd.Parameters.AddWithValue("@Jml", jumlah);
                    cmd.Parameters.AddWithValue("@Tot", total);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.ExecuteNonQuery();

                    int poinTambahan = (int)(total / 100000);
                    if (poinTambahan > 0)
                    {
                        string queryPoin = "UPDATE Pelanggan SET Poin_Loyalitas = Poin_Loyalitas + @Poin WHERE ID_Pelanggan = @ID";
                        SqlCommand cmdPoin = new SqlCommand(queryPoin, conn);
                        cmdPoin.Parameters.AddWithValue("@Poin", poinTambahan);
                        cmdPoin.Parameters.AddWithValue("@ID", idPelanggan);
                        cmdPoin.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data berhasil disimpan!");
                    TampilkanDataPemesanan();
                    BersihkanForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal simpan: " + ex.Message);
                }
            }
        }


        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPemesanan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvPemesanan.SelectedRows[0].Cells["ID_Pemesanan"].Value);
                using (SqlConnection conn = Koneksi.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM PemesananLayanan WHERE ID_Pemesanan=@ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data berhasil dihapus!");
                        TampilkanDataPemesanan();
                        BersihkanForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal hapus: " + ex.Message);
                    }
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            BersihkanForm();
        }

        private void dgvPemesanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPemesanan.Rows[e.RowIndex].Cells["ID_Pemesanan"].Value != null)
            {
                DataGridViewRow row = dgvPemesanan.Rows[e.RowIndex];
                txtIDPemesanan.Text = row.Cells["ID_Pemesanan"].Value.ToString();

                // Gunakan ValueMember agar isian dropdown tetap benar
                cmbPelanggan.SelectedValue = row.Cells["Nama_Pelanggan"].Value.ToString();
                cmbLayanan.SelectedValue = row.Cells["Nama_Layanan"].Value.ToString();
                cmbKategori.SelectedItem = dgvPemesanan.Rows[e.RowIndex].Cells["Status_Pembayaran"].Value.ToString();
                dtpTanggal.Value = Convert.ToDateTime(row.Cells["Tanggal_Pemesanan"].Value);
            }
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            Form1 formPelanggan = new Form1();
            this.Hide();
            formPelanggan.ShowDialog();
        }

        private void btnLayanan_Click(object sender, EventArgs e)
        {
            Form2 formLayanan = new Form2();
            this.Hide();
            formLayanan.ShowDialog();
        }

        private void cmbPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelJenisPesanan_Click(object sender, EventArgs e)
        {

        }
    }
}