using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main()
    {
        // Baca string biner dari file teks
        string binaryString = File.ReadAllText("result1.txt");

        // Tentukan lebar dan tinggi gambar (misalnya 100x100)
        int width = 96;
        int height = 103;

        // Buat objek Bitmap dengan ukuran yang ditentukan
        Bitmap image = new Bitmap(width, height);

        // Hitung jumlah karakter yang akan dibaca (lebar x tinggi)
        int length = width * height;

        // Loop untuk mengisi gambar berdasarkan string biner
        for (int i = 0; i < length; i++)
        {
            // Ambil karakter biner dari string
            char binaryChar = binaryString[i];

            // Ubah karakter biner menjadi warna hitam (0) atau putih (1)
            Color color = binaryChar == '1' ? Color.White : Color.Black;

            // Hitung koordinat piksel dalam gambar
            int x = i % width;
            int y = i / width;

            // Set warna piksel dalam gambar
            image.SetPixel(x, y, color);
        }

        // Simpan gambar sebagai file bmp
        image.Save("output.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

        Console.WriteLine("Gambar berhasil dibuat.");
    }
}