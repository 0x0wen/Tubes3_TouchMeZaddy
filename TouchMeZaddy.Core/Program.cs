using System;
using System.Drawing;
using System.IO;
using System.Text;

partial class Program
{
    static void Main()
    {
        Bitmap fingerprintImage = new Bitmap("sample/sample1.bmp");

        string binaryString = ConvertToBinaryString(fingerprintImage);

        File.WriteAllText("result.txt", binaryString);

        Console.WriteLine("Hasil telah ditulis ke dalam file result.txt");
    }

    static string ConvertToBinaryString(Bitmap image)
    {
        StringBuilder binaryStringBuilder = new StringBuilder();

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Color pixel = image.GetPixel(x, y);
                int pixelValue = (pixel.R + pixel.G + pixel.B) / 3;
                char binaryChar = pixelValue > 128 ? '1' : '0';
                binaryStringBuilder.Append(binaryChar);
            }
        }

        return binaryStringBuilder.ToString();
    }
}
