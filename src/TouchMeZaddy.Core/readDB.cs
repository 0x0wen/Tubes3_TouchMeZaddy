using System;
using System.Data.SQLite;
using System.Drawing;
using System.Net.WebSockets;

partial class Program
{
    static void readDB(List<KeyValuePair<string, string>> imagePath)
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
        }
    }
}
