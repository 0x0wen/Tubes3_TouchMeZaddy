using System;
using System.Drawing;
using System.IO;
using System.Text;

partial class Program
{
    static void Main()
    {
        Bitmap fingerprintImage = new Bitmap("sample/sample1.bmp");

        string binaryString = BMPToBinaryString(fingerprintImage);

        string ascii = BinaryStringToAscii(binaryString);

        File.WriteAllText("result.txt", ascii);

        Console.WriteLine("Hasil telah ditulis ke dalam file result.txt");
    }
}
