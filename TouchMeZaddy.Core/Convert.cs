using System;
using System.Drawing;
using System.Text;

partial class Program
{
    static string BinaryStringToAscii(string binaryString)
    {
        StringBuilder asciiStringBuilder = new StringBuilder();

        // Pastikan panjang string biner adalah kelipatan 8
        int paddingLength = 8 - (binaryString.Length % 8);
        if (paddingLength != 8)
        {
            binaryString = binaryString.PadLeft(binaryString.Length + paddingLength, '0');
        }

        // Konversi setiap 8 bit menjadi karakter ASCII
        for (int i = 0; i < binaryString.Length; i += 8)
        {
            string eightBits = binaryString.Substring(i, 8);
            int asciiValue = Convert.ToInt32(eightBits, 2);
            char asciiChar = (char)asciiValue;
            asciiStringBuilder.Append(asciiChar);
        }

        return asciiStringBuilder.ToString();
    }

    static string BMPToBinaryString(Bitmap image)
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