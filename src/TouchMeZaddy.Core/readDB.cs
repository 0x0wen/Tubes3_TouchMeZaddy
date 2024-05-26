using System;
using System.Data.SQLite;
using System.Drawing;
using System.Net.WebSockets;

partial class Program
{
    static void readDB(List<KeyValuePair<string, string>> imagePath, List<KeyValuePair<string, Biodata>> biodata)
    {
        // Membuat koneksi ke database
        using (SQLiteConnection connection = new SQLiteConnection("Data Source=biodata.db;Version=3;"))
        {
            connection.Open();

            // Query untuk mengambil data dari tabel
            string query = "SELECT nama, berkas_citra FROM sidik_jari";

            // Membuat SQLiteCommand
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                // Membaca hasil query
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Mendapatkan nilai dari kolom pertama
                        string name = reader["nama"].ToString();
                        string citra = reader["berkas_citra"].ToString();
                        // System.Console.WriteLine(name);
                        // System.Console.WriteLine(citra);

                        KeyValuePair<string, string> temp = new KeyValuePair<string, string>(name, citra);
                        imagePath.Add(temp);
                    }
                }
            }

            // Query untuk mengambil data dari tabel
            query = "SELECT NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan FROM biodata";

            // Membuat SQLiteCommand
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                // Membaca hasil query
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Biodata bioTemp = new Biodata(reader["NIK"].ToString(), reader["nama"].ToString(), reader["tempat_lahir"].ToString(), reader["tanggal_lahir"].ToString(), reader["jenis_kelamin"].ToString(), reader["golongan_darah"].ToString(), reader["alamat"].ToString(), reader["agama"].ToString(), reader["status_perkawinan"].ToString(), reader["pekerjaan"].ToString(), reader["kewarganegaraan"].ToString());
                        KeyValuePair<string, Biodata> temp = new KeyValuePair<string, Biodata>(reader["nama"].ToString(), bioTemp);
                        biodata.Add(temp);
                    }
                }
            }
        }
    }
}
