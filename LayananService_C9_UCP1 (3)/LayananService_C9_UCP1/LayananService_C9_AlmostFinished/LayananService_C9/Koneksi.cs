﻿using System.Data.SqlClient;

namespace LayananService_C9
{
    internal class Koneksi
    {
        private static string connectionString = "Data Source=ARSYAN\\SYANDY_ARDA;Initial Catalog=SistemManajemenPelangganDanLayananOtomotif2;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
