namespace LayananService_C9
{
    partial class Form2
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
            this.txtIDLayanan = new System.Windows.Forms.TextBox();
            this.txtNamaLayanan = new System.Windows.Forms.TextBox();
            this.numHarga = new System.Windows.Forms.NumericUpDown();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.dgvLayanan = new System.Windows.Forms.DataGridView();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnPelanggan = new System.Windows.Forms.Button();
            this.btnPemesanan = new System.Windows.Forms.Button();
            this.labelJumlahHarga = new System.Windows.Forms.Label();
            this.labelKategoriLayanan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numHarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLayanan)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIDLayanan
            // 
            this.txtIDLayanan.Enabled = false;
            this.txtIDLayanan.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtIDLayanan.Location = new System.Drawing.Point(138, 124);
            this.txtIDLayanan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIDLayanan.Name = "txtIDLayanan";
            this.txtIDLayanan.ReadOnly = true;
            this.txtIDLayanan.Size = new System.Drawing.Size(270, 26);
            this.txtIDLayanan.TabIndex = 0;
            this.txtIDLayanan.Text = "ID Layanan";
            this.txtIDLayanan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNamaLayanan
            // 
            this.txtNamaLayanan.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtNamaLayanan.Location = new System.Drawing.Point(138, 178);
            this.txtNamaLayanan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNamaLayanan.Name = "txtNamaLayanan";
            this.txtNamaLayanan.Size = new System.Drawing.Size(270, 26);
            this.txtNamaLayanan.TabIndex = 1;
            this.txtNamaLayanan.Text = "Nama Layanan";
            this.txtNamaLayanan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numHarga
            // 
            this.numHarga.DecimalPlaces = 2;
            this.numHarga.Location = new System.Drawing.Point(183, 254);
            this.numHarga.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numHarga.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numHarga.Name = "numHarga";
            this.numHarga.Size = new System.Drawing.Size(178, 26);
            this.numHarga.TabIndex = 2;
            this.numHarga.ThousandsSeparator = true;
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Items.AddRange(new object[] {
            "Standar",
            "Premium"});
            this.cmbKategori.Location = new System.Drawing.Point(183, 319);
            this.cmbKategori.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(177, 28);
            this.cmbKategori.TabIndex = 3;
            // 
            // dgvLayanan
            // 
            this.dgvLayanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLayanan.Location = new System.Drawing.Point(564, 115);
            this.dgvLayanan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvLayanan.Name = "dgvLayanan";
            this.dgvLayanan.RowHeadersWidth = 51;
            this.dgvLayanan.RowTemplate.Height = 24;
            this.dgvLayanan.Size = new System.Drawing.Size(748, 439);
            this.dgvLayanan.TabIndex = 4;
            this.dgvLayanan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLayanan_CellClick);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(163, 404);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(96, 36);
            this.btnSimpan.TabIndex = 6;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(292, 404);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(89, 36);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(163, 469);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(96, 36);
            this.btnHapus.TabIndex = 8;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(292, 469);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(89, 36);
            this.btnBatal.TabIndex = 9;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnPelanggan
            // 
            this.btnPelanggan.Location = new System.Drawing.Point(604, 615);
            this.btnPelanggan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPelanggan.Name = "btnPelanggan";
            this.btnPelanggan.Size = new System.Drawing.Size(290, 45);
            this.btnPelanggan.TabIndex = 10;
            this.btnPelanggan.Text = "Pelanggan";
            this.btnPelanggan.UseVisualStyleBackColor = true;
            this.btnPelanggan.Click += new System.EventHandler(this.btnPelanggan_Click);
            // 
            // btnPemesanan
            // 
            this.btnPemesanan.Location = new System.Drawing.Point(982, 615);
            this.btnPemesanan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPemesanan.Name = "btnPemesanan";
            this.btnPemesanan.Size = new System.Drawing.Size(290, 45);
            this.btnPemesanan.TabIndex = 11;
            this.btnPemesanan.Text = "Pemesanan";
            this.btnPemesanan.UseVisualStyleBackColor = true;
            this.btnPemesanan.Click += new System.EventHandler(this.btnPemesanan_Click);
            // 
            // labelJumlahHarga
            // 
            this.labelJumlahHarga.AutoSize = true;
            this.labelJumlahHarga.Location = new System.Drawing.Point(35, 256);
            this.labelJumlahHarga.Name = "labelJumlahHarga";
            this.labelJumlahHarga.Size = new System.Drawing.Size(108, 20);
            this.labelJumlahHarga.TabIndex = 14;
            this.labelJumlahHarga.Text = "Jumlah Harga";
            // 
            // labelKategoriLayanan
            // 
            this.labelKategoriLayanan.AutoSize = true;
            this.labelKategoriLayanan.Location = new System.Drawing.Point(35, 322);
            this.labelKategoriLayanan.Name = "labelKategoriLayanan";
            this.labelKategoriLayanan.Size = new System.Drawing.Size(133, 20);
            this.labelKategoriLayanan.TabIndex = 15;
            this.labelKategoriLayanan.Text = "Kategori Layanan";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 722);
            this.Controls.Add(this.labelKategoriLayanan);
            this.Controls.Add(this.labelJumlahHarga);
            this.Controls.Add(this.btnPemesanan);
            this.Controls.Add(this.btnPelanggan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.dgvLayanan);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.numHarga);
            this.Controls.Add(this.txtNamaLayanan);
            this.Controls.Add(this.txtIDLayanan);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.Text = "Layanan Service C9";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLayanan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIDLayanan;
        private System.Windows.Forms.TextBox txtNamaLayanan;
        private System.Windows.Forms.NumericUpDown numHarga;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.DataGridView dgvLayanan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnPelanggan;
        private System.Windows.Forms.Button btnPemesanan;
        private System.Windows.Forms.Label labelJumlahHarga;
        private System.Windows.Forms.Label labelKategoriLayanan;
    }
}