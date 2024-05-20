using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using System.Runtime.Intrinsics.X86;

partial class Program
{
    static void Main()
    {
        Bitmap fingerprintImage1 = new Bitmap("./sample/sample (1).bmp");
        string binaryString1 = BMPToBinaryString(fingerprintImage1);
        binaryString1 = binaryString1.Substring(binaryString1.Length/2, 32);
        string ascii1 = BinaryStringToAscii(binaryString1);
        Bitmap fingerprintImage2 = new Bitmap("./sample/sample (1).bmp");
        string binaryString2 = BMPToBinaryString(fingerprintImage2);
        string ascii2 = BinaryStringToAscii(binaryString2);

        Console.WriteLine("hasil bm: " + BmMatch(ascii2, ascii1));
        Console.WriteLine("hasil kmp: " + KmpMatch(ascii2, ascii1));
        // Bitmap fingerprintImage2 = new Bitmap("sample/sample (2).bmp");
        // string binaryString2 = BMPToBinaryStringTarget(fingerprintImage2);
        // string ascii2 = BinaryStringToAscii(binaryString2);
        double max = 0;
        int idx = 0;
        Stopwatch stopwatch = new Stopwatch();
        // Console.WriteLine("biner 1");
        // Console.WriteLine(binaryString1);
        // Console.WriteLine("ascii 1");
        // Console.WriteLine(ascii1);
        // Console.WriteLine("biner 2");
        // Console.WriteLine(binaryString2);
        // Console.WriteLine("ascii 2");
        // Console.WriteLine(ascii2);
        // using StreamWriter writer = new StreamWriter("output.txt");
        // writer.WriteLine("biner 1:");
        // writer.WriteLine(binaryString1);
        // writer.WriteLine();
        // writer.WriteLine("biner 2:");
        // writer.WriteLine(binaryString2);
        // writer.WriteLine("asci 1:");
        // writer.WriteLine(ascii1);
        // writer.WriteLine();
        // writer.WriteLine("asci 2:");
        // writer.WriteLine(ascii2);

        // int[] debugId = new int[6000];
        // int tempIdx = 0;

        // stopwatch.Start();
        // for (int i = 2; i <= 6000; i++) {
        //     Console.WriteLine("ngecek sampel ke-" + i);
        //     Bitmap fingerprintImage2 = new Bitmap("sample/sample (" + i + ").bmp");
        //     string binaryString2 = BMPToBinaryString(fingerprintImage2);
        //     // if (binaryString1.Length != binaryString2.Length) {
        //     //     debugId[tempIdx] = i;
        //     //     tempIdx++;
        //     // }
        //     string ascii2 = BinaryStringToAscii(binaryString2);
        //     // double similarity = LevenshteinDistance(ascii1, ascii2);
        //     double similarity = LevenshteinDistance(ascii2, ascii1);
        //     if (similarity > max) {
        //         idx = i;
        //         max = similarity;
        //     }
        //     // if (similarity != -1) {
        //     //     debugId[tempIdx] = i;
        //     //     tempIdx++;
        //     // }
        //     // Console.WriteLine("kesamaannya "+ similarity);
        // }
        // stopwatch.Stop();

        // Console.WriteLine("\nkemiripan yang paling mirip adalah dengan sampel ke-" + idx + " dengan kemiripan " + max + " persen");
        // Console.WriteLine("Waktu yang dibutuhkan: " + stopwatch.ElapsedMilliseconds/1000 + " detik");

        // // Console.WriteLine("id debug utk sampel ini\n");
        // // for (int i = 0; i < tempIdx; i++) {
        // //     Console.WriteLine(debugId[i]);
        // // }

    }
}
