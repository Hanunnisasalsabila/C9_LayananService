namespace LayananService_C9
{
    partial class FormPemesananLayanan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbPelanggan = new System.Windows.Forms.ComboBox();
            this.cmbLayanan = new System.Windows.Forms.ComboBox();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.dgvPemesanan = new System.Windows.Forms.DataGridView();
            this.btnPelanggan = new System.Windows.Forms.Button();
            this.btnLayanan = new System.Windows.Forms.Button();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.txtIDPemesanan = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemesanan)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPelanggan
            // 
            this.cmbPelanggan.Location = new System.Drawing.Point(488, 92);
            this.cmbPelanggan.Name = "cmbPelanggan";
            this.cmbPelanggan.Size = new System.Drawing.Size(236, 24);
            this.cmbPelanggan.TabIndex = 12;
            // 
            // cmbLayanan
            // 
            this.cmbLayanan.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbLayanan.FormattingEnabled = true;
            this.cmbLayanan.Location = new System.Drawing.Point(488, 136);
            this.cmbLayanan.Name = "cmbLayanan";
            this.cmbLayanan.Size = new System.Drawing.Size(236, 24);
            this.cmbLayanan.TabIndex = 1;
            this.cmbLayanan.Text = "Pilih Layanan";
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(488, 229);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(236, 22);
            this.dtpTanggal.TabIndex = 2;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(931, 86);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(84, 39);
            this.btnSimpan.TabIndex = 3;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(931, 159);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(84, 39);
            this.btnHapus.TabIndex = 5;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(931, 223);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(84, 39);
            this.btnBatal.TabIndex = 6;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // dgvPemesanan
            // 
            this.dgvPemesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPemesanan.Location = new System.Drawing.Point(51, 366);
            this.dgvPemesanan.Name = "dgvPemesanan";
            this.dgvPemesanan.RowHeadersWidth = 51;
            this.dgvPemesanan.RowTemplate.Height = 24;
            this.dgvPemesanan.Size = new System.Drawing.Size(1086, 199);
            this.dgvPemesanan.TabIndex = 7;
            // 
            // btnPelanggan
            // 
            this.btnPelanggan.Location = new System.Drawing.Point(343, 313);
            this.btnPelanggan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPelanggan.Name = "btnPelanggan";
            this.btnPelanggan.Size = new System.Drawing.Size(236, 32);
            this.btnPelanggan.TabIndex = 9;
            this.btnPelanggan.Text = "Pelanggan";
            this.btnPelanggan.UseVisualStyleBackColor = true;
            this.btnPelanggan.Click += new System.EventHandler(this.btnPelanggan_Click);
            // 
            // btnLayanan
            // 
            this.btnLayanan.Location = new System.Drawing.Point(622, 313);
            this.btnLayanan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLayanan.Name = "btnLayanan";
            this.btnLayanan.Size = new System.Drawing.Size(236, 32);
            this.btnLayanan.TabIndex = 10;
            this.btnLayanan.Text = "Layanan";
            this.btnLayanan.UseVisualStyleBackColor = true;
            this.btnLayanan.Click += new System.EventHandler(this.btnLayanan_Click);
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Items.AddRange(new object[] {
            "Lunas",
            "Belum Lunas"});
            this.cmbKategori.Location = new System.Drawing.Point(488, 180);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(236, 24);
            this.cmbKategori.TabIndex = 11;
            // 
            // txtIDPemesanan
            // 
            this.txtIDPemesanan.Location = new System.Drawing.Point(1180, 197);
            this.txtIDPemesanan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDPemesanan.Name = "txtIDPemesanan";
            this.txtIDPemesanan.Size = new System.Drawing.Size(89, 22);
            this.txtIDPemesanan.TabIndex = 8;
            this.txtIDPemesanan.Visible = false;
            // 
            // FormPemesananLayanan
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 577);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.btnLayanan);
            this.Controls.Add(this.btnPelanggan);
            this.Controls.Add(this.txtIDPemesanan);
            this.Controls.Add(this.dgvPemesanan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.cmbLayanan);
            this.Controls.Add(this.cmbPelanggan);
            this.Name = "FormPemesananLayanan";
            this.Text = "IDPemesanan";
            this.Load += new System.EventHandler(this.FormPemesananLayanan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemesanan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPelanggan;
        private System.Windows.Forms.ComboBox cmbLayanan;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.DataGridView dgvPemesanan;
        private System.Windows.Forms.Button btnPelanggan;
        private System.Windows.Forms.Button btnLayanan;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.TextBox txtIDPemesanan;
    }
}