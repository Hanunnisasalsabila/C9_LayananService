CREATE DATABASE SistemManajemenPelanggandanLayananOtomotif;

CREATE TABLE Pelanggan(
    ID_Pelanggan INT IDENTITY PRIMARY KEY,
    Nama_Pelanggan VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL CHECK (Email LIKE '%@%'),
    No_Telp VARCHAR(15) NOT NULL CHECK (
        No_Telp LIKE '08%' AND 
        LEN(No_Telp) BETWEEN 12 AND 15 AND 
        No_Telp NOT LIKE '%[^0-9]%'
    ),
    Poin_Loyalitas INT DEFAULT 0
);

CREATE TABLE Layanan (
    ID_Layanan INT IDENTITY PRIMARY KEY,
    Nama_Layanan VARCHAR(100) NOT NULL,
    Harga DECIMAL(10, 2) NOT NULL CHECK (Harga >= 0),
    Kategori_Layanan VARCHAR(7) CHECK (Kategori_Layanan IN ('Standar', 'Premium'))
);

CREATE TABLE PemesananLayanan (
    ID_Pemesanan INT IDENTITY PRIMARY KEY,
    ID_Pelanggan INT NOT NULL,
    ID_Layanan INT NOT NULL,
    Tanggal_Pemesanan DATE NOT NULL DEFAULT GETDATE(),
    Jumlah_Layanan INT DEFAULT 1,
    Total_Biaya DECIMAL(10, 2) NOT NULL,
    Status_Pembayaran VARCHAR(5) CHECK (Status_Pembayaran IN ('Lunas','Belum Lunas')),
    FOREIGN KEY (ID_Pelanggan) REFERENCES Pelanggan(ID_Pelanggan),
    FOREIGN KEY (ID_Layanan) REFERENCES Layanan(ID_Layanan)
);

