using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Diagnostics;

partial class Program
{
    static void Main()
    {
        Bitmap fingerprintImage1 = new Bitmap("sample/sample (2).bmp");
        string binaryString1 = BMPToBinaryString(fingerprintImage1);
        string ascii1 = BinaryStringToAscii(binaryString1);
        double max = 0;
        int idx = 0;
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        for (int i = 3; i <= 6000; i++) {
            Console.WriteLine("ngecek sampel ke-" + i);
            Bitmap fingerprintImage2 = new Bitmap("sample/sample (" + i + ").bmp");
            string binaryString2 = BMPToBinaryString(fingerprintImage2);
            string ascii2 = BinaryStringToAscii(binaryString2);
            double sim = KMP(ascii1, ascii2);
            if (sim > max) {
                idx = i;
                max = sim;
            }
        }
        stopwatch.Stop();

        Console.WriteLine("\nkemiripan yang paling mirip adalah dengan sampel ke-" + idx + " dengan kemiripan " + max + " persen");
        Console.WriteLine("Waktu yang dibutuhkan: " + stopwatch.ElapsedMilliseconds/1000 + " detik");
    }
}
