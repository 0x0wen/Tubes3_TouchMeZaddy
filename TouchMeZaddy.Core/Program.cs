using System;
using System.Drawing;
using System.IO;
using System.Text;

partial class Program
{
    static void Main()
    {
        Bitmap fingerprintImage1 = new Bitmap("sample/sample1.bmp");
        Bitmap fingerprintImage2 = new Bitmap("sample/sample2.bmp");

        string binaryString1 = BMPToBinaryString(fingerprintImage1);
        string binaryString2 = BMPToBinaryString(fingerprintImage2);

        string ascii1 = BinaryStringToAscii(binaryString1);
        string ascii2 = BinaryStringToAscii(binaryString2);

        double sim = KMP(ascii1, ascii2);
        
        Console.WriteLine("kemiripannya adalah " + sim);
    }
}
