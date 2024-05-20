using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics.Arm;

partial class Program
{
    static void Main()
    {
        Console.WriteLine("Masukkan id gambar sampel yang ingin dijadikan referensi");
        int id = Convert.ToInt32(Console.ReadLine());
        Bitmap targetImage = new Bitmap("./sample/sample (" + id + ").bmp");
        string targetBinary = BMPToBinaryString(targetImage);
        string targetAscii = BinaryStringToAscii(targetBinary.Substring(targetBinary.Length/2, 32));

        int exactIdx = -1;
        int notExactIdx = -1;
        int distance = -1;
        System.Console.WriteLine("Pencarian dengan KMP dimulai");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 1; i <= 6000; i++) {
            // if (i == id) {
            //     continue;
            // }
            // else {
                Bitmap searchImage = new Bitmap("sample/sample (" + i + ").bmp");
                System.Console.WriteLine("ngecek sampel ke-" + i);
                string searchAscii = BinaryStringToAscii(BMPToBinaryString(searchImage));
                int result = KmpMatch(searchAscii, targetAscii);
                if (result != -1) {
                    exactIdx = i;
                    break;
                }
            // }
        }
        // if (exactIdx == -1) {
        //     Console.WriteLine("Exact match tidak ditemukan");
        //     Console.WriteLine("Mengulangi pencarian dengan Levenshtein");
        //     for (int i = 1; i <= 6000; i++) {
        //         if (i == id) {
        //             continue;
        //         }
        //         else {
        //             Bitmap searchImage = new Bitmap("sample/sample (" + i + ").bmp");
        //             // System.Console.WriteLine("ngecek sampel ke-" + i);
        //             string searchBinary = BMPToBinaryString(searchImage);
        //             string searchAscii = BinaryStringToAscii(searchBinary.Substring(searchBinary.Length/2, 32));
        //             // int temp = LevenshteinFullMatrix(targetAscii, searchAscii, targetAscii.Length, searchAscii.Length);
        //             // int temp = LevenshteinTwoMatrixRows(targetAscii, searchAscii);
        //             int temp = LevenshteinTwoMatrixRows(targetBinary.Substring(targetBinary.Length/2, 32), searchBinary.Substring(searchBinary.Length/2, 32));
        //             Console.WriteLine(temp);
        //             if (distance == -1) {
        //                 distance = temp;
        //             }
        //             if (temp < distance) {
        //                 distance = temp;
        //                 notExactIdx = i;
        //             }
        //         }
        //     }
        // }
        stopwatch.Stop();

        if (exactIdx != -1) {
            Console.WriteLine("Exact match ditemukan pada gambar dengan id " + exactIdx);
        }
        else {
            Console.WriteLine("Gambar termirip ditemukan pada gambar dengan id " + notExactIdx + " dengan Levenshtein Distance sebesar " + distance);
        }
        Console.WriteLine("Waktu yang dibutuhkan: " + (float)stopwatch.ElapsedMilliseconds/1000 + " detik");
    }
}
