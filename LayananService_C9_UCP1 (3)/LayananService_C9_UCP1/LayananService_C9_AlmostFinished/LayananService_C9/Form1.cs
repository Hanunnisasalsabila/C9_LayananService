using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LayananService_C9
{
    public partial class Form1 : Form
    {
        Panel panelLogin;
        TextBox txtUsername;
        TextBox txtPassword;
        Button btnLogin;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
            SetupLoginPanel();
            panelLogin.BringToFront();
        }
        
        private void SetupLoginPanel()
        {
            panelLogin = new Panel();
            panelLogin.Size = new Size(400, 200);
            panelLogin.Location = new Point((this.ClientSize.Width - 400) / 2, (this.ClientSize.Height - 200) / 2);
            panelLogin.BackColor = Color.White;
            panelLogin.BorderStyle = BorderStyle.FixedSingle;

            Label lblUser = new Label();
            lblUser.Text = "Username:";
            lblUser.Location = new Point(30, 30);
            panelLogin.Controls.Add(lblUser);

            txtUsername = new TextBox();
            txtUsername.Location = new Point(120, 30);
            panelLogin.Controls.Add(txtUsername);

            Label lblPass = new Label();
            lblPass.Text = "Password:";
            lblPass.Location = new Point(30, 70);
            panelLogin.Controls.Add(lblPass);

            txtPassword = new TextBox();
            txtPassword.Location = new Point(120, 70);
            txtPassword.PasswordChar = '*';
            panelLogin.Controls.Add(txtPassword);

            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new Point(120, 110);
            btnLogin.Click += BtnLogin_Click;
            panelLogin.Controls.Add(btnLogin);

            this.Controls.Add(panelLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Admin WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login berhasil!");
                        panelLogin.Visible = false;
                        TampilkanDataPelanggan();
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat login: " + ex.Message);
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // Method untuk menampilkan data pelanggan ke DataGridView
        void TampilkanDataPelanggan()
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Pelanggan", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPelanggan.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menampilkan data: " + ex.Message);
                }
            }
        }
        void BersihkanForm()
        {
            txtNama.Text = "";
            txtEmail.Text = "";
            txtNoTelp.Text = "";
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
            lblTitle.Text = "Form Pemesanan";
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold); // Ukuran lebih kecil dari sebelumnya (18 → 14)
            lblTitle.ForeColor = Color.White;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 20); // Sedikit geser agar tidak menimpa form field

            background.Controls.Add(lblTitle);
        }

        void TambahPelanggan()
        {
            using (SqlConnection conn = Koneksi.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Pelanggan (Nama_Pelanggan, Email, No_Telp) VALUES (@Nama, @Email, @NoTelp)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@NoTelp", txtNoTelp.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data pelanggan berhasil ditambahkan!");
                    TampilkanDataPelanggan(); // refresh tabel
                    BersihkanForm(); // kosongkan input
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menambahkan data: " + ex.Message);
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            TambahPelanggan();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPelanggan.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvPelanggan.SelectedRows[0].Cells["ID_Pelanggan"].Value);
                    using (SqlConnection conn = Koneksi.GetConnection())
                    {
                        try
                        {
                            conn.Open();                                         
                            string query = "DELETE FROM Pelanggan WHERE ID_Pelanggan = @ID";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Data berhasil dihapus!");
                            TampilkanDataPelanggan();
                            BersihkanForm();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Gagal menghapus data: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih baris data yang ingin dihapus.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPelanggan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvPelanggan.SelectedRows[0].Cells["ID_Pelanggan"].Value);
                using (SqlConnection conn = Koneksi.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE Pelanggan SET Nama_Pelanggan = @Nama, Email = @Email, No_Telp = @NoTelp WHERE ID_Pelanggan = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@NoTelp", txtNoTelp.Text);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data pelanggan berhasil diperbarui!");
                        TampilkanDataPelanggan();
                        BersihkanForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal memperbarui data: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin diedit.");
            }
        }

        private void dgvPelanggan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNama.Text = dgvPelanggan.Rows[e.RowIndex].Cells["Nama_Pelanggan"].Value.ToString();
                txtEmail.Text = dgvPelanggan.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtNoTelp.Text = dgvPelanggan.Rows[e.RowIndex].Cells["No_Telp"].Value.ToString();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            BersihkanForm();
            dgvPelanggan.ClearSelection();
        }

        private void btnLayanan_Click(object sender, EventArgs e)
        {
            Form2 formLayanan = new Form2();
            this.Hide();
            formLayanan.ShowDialog();
        }
    }
}
