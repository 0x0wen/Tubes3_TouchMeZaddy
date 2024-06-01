using System;
using System.Drawing;
using System.Text;

public class Conversion
{
    static public string BinaryStringToAscii(string binaryString)
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

    static public string BMPToBinaryString(Bitmap image)
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

    static public Bitmap Resize(Bitmap small, Bitmap big)
    {
        // Get the dimensions of the small image
        int smallWidth = small.Width;
        int smallHeight = small.Height;

        // Get the dimensions of the big image
        int bigWidth = big.Width;
        int bigHeight = big.Height;

        // Calculate the aspect ratio of the big image
        double aspectRatio = (double)bigWidth / bigHeight;

        // Calculate new dimensions for the big image
        int newWidth, newHeight;
        if (aspectRatio > 1)
        {
            // Landscape orientation
            newWidth = smallWidth;
            newHeight = (int)(smallWidth / aspectRatio);
        }
        else
        {
            // Portrait orientation
            newHeight = smallHeight;
            newWidth = (int)(smallHeight * aspectRatio);
        }

        // Resize the big image
        Bitmap resizedBitmap = new Bitmap(big, new Size(newWidth, newHeight));
        
        return resizedBitmap;
    }
}
