using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayananService_C9
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SetupUI();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TampilkanDataLayanan();
            cmbKategori.SelectedIndex = 0;
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
            lblTitle.Text = "Form Layanan";
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold); // Ukuran lebih kecil dari sebelumnya (18 → 14)
            lblTitle.ForeColor = Color.White;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 20); // Sedikit geser agar tidak menimpa form field

            background.Controls.Add(lblTitle);
        }

        void TampilkanDataLayanan()
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Layanan", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLayanan.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menampilkan data: " + ex.Message);
                }
            }
        }

        void TambahLayanan()
        {
            if (string.IsNullOrWhiteSpace(txtNamaLayanan.Text))
            {
                MessageBox.Show("Nama layanan harus diisi.");
                return;
            }
            if (numHarga.Value <= 0)
            {
                MessageBox.Show("Harga harus lebih dari 0.");
                return;
            }

            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Layanan (Nama_Layanan, Harga, Kategori_Layanan) VALUES (@Nama, @Harga, @Kategori)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nama", txtNamaLayanan.Text);
                    cmd.Parameters.AddWithValue("@Harga", numHarga.Value);
                    cmd.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data layanan berhasil ditambahkan!");
                    TampilkanDataLayanan();
                    BersihkanFormLayanan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menambahkan data: " + ex.Message);
                }
            }
        }


        void EditLayanan()
        {
            if (string.IsNullOrEmpty(txtIDLayanan.Text))
            {
                MessageBox.Show("Pilih data yang ingin diedit.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNamaLayanan.Text))
            {
                MessageBox.Show("Nama layanan harus diisi.");
                return;
            }
            if (numHarga.Value <= 0)
            {
                MessageBox.Show("Harga harus lebih dari 0.");
                return;
            }

            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Layanan SET Nama_Layanan = @Nama, Harga = @Harga, Kategori_Layanan = @Kategori WHERE ID_Layanan = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nama", txtNamaLayanan.Text);
                    cmd.Parameters.AddWithValue("@Harga", numHarga.Value);
                    cmd.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtIDLayanan.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data layanan berhasil diperbarui!");
                    TampilkanDataLayanan();
                    BersihkanFormLayanan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengedit data: " + ex.Message);
                }
            }
        }


        void HapusLayanan()
        {
            if (string.IsNullOrEmpty(txtIDLayanan.Text))
            {
                MessageBox.Show("Pilih data yang ingin dihapus.");
                return;
            }

            DialogResult result = MessageBox.Show("Yakin ingin menghapus layanan ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = Koneksi.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Layanan WHERE ID_Layanan = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtIDLayanan.Text));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data layanan berhasil dihapus!");
                        TampilkanDataLayanan();
                        BersihkanFormLayanan();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus data: " + ex.Message);
                    }
                }
            }
        }

        void BersihkanFormLayanan()
        {
            txtIDLayanan.Text = "";
            txtNamaLayanan.Text = "";
            numHarga.Value = 0;
            cmbKategori.SelectedIndex = 0;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            TambahLayanan();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditLayanan();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            HapusLayanan();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            BersihkanFormLayanan();
        }

        private void dgvLayanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIDLayanan.Text = dgvLayanan.Rows[e.RowIndex].Cells["ID_Layanan"].Value.ToString();
                txtNamaLayanan.Text = dgvLayanan.Rows[e.RowIndex].Cells["Nama_Layanan"].Value.ToString();
                numHarga.Value = Convert.ToDecimal(dgvLayanan.Rows[e.RowIndex].Cells["Harga"].Value);
                cmbKategori.SelectedItem = dgvLayanan.Rows[e.RowIndex].Cells["Kategori_Layanan"].Value.ToString();
            }
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            Form1 formPelanggan = new Form1();
            this.Hide();
            formPelanggan.ShowDialog();
        }

        private void btnPemesanan_Click(object sender, EventArgs e)
        {
            FormPemesananLayanan formPemesanan = new FormPemesananLayanan();
            this.Hide();
            formPemesanan.ShowDialog();
        }
    }
}
