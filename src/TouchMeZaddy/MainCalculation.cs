using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;
namespace TouchMeZaddy;

public class MainCalculation
{
    static public Result KMPCalculation(Bitmap targetImage)
    {
        List<KeyValuePair<string, string>> imagePath = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, Biodata>> biodata = new List<KeyValuePair<string, Biodata>>();
        ReadDatabase.DB(imagePath, biodata);
        string targetBinary = Conversion.BMPToBinaryString(targetImage);
        string targetAscii = Conversion.BinaryStringToAscii(targetBinary.Substring(targetBinary.Length / 2, 32)); // panjang biner / 8 = panjang ascii

        int exactIdx = -1;
        int notExactIdx = -1;
        float similarity = -1;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < imagePath.Count; i++)
        {
            Bitmap searchImage = new Bitmap("../../test/" + imagePath[i].Value);
            if ((double)targetImage.Width / targetImage.Height != (double)searchImage.Width / searchImage.Height)
            {
                continue;
            }
            searchImage = Conversion.Resize(targetImage, searchImage); // normalisasi
            // Console.WriteLine("ngecek sampel ke-" + i);
            string searchAscii = Conversion.BinaryStringToAscii(Conversion.BMPToBinaryString(searchImage));
            int kmpResult = Comparison.KmpMatch(searchAscii, targetAscii); // kalo mau bm tinggal ubah jadi bmmatch
            if (kmpResult != -1)
            {
                exactIdx = i;
                similarity = 100;
                break;
            }
        }
        if (exactIdx == -1)
        {
            targetAscii = Conversion.BinaryStringToAscii(targetBinary.Substring(targetBinary.Length / 2 - targetImage.Width * 4 / 10, targetImage.Width * 8 / 10)); // panjang biner / 8 = panjang ascii
            for (int i = 0; i < imagePath.Count; i++)
            {
                Bitmap searchImage = new Bitmap("../../test/" + imagePath[i].Value);
                if ((double)targetImage.Width / targetImage.Height != (double)searchImage.Width / searchImage.Height)
                {
                    continue;
                }
                searchImage = Conversion.Resize(targetImage, searchImage); // normalisasi
                // Console.WriteLine("ngecek sampel ke-" + i);
                string searchBinary = Conversion.BMPToBinaryString(searchImage);
                string searchAscii = Conversion.BinaryStringToAscii(searchBinary);
                float distanceTemp = 0;

                // tuning variabel
                // jgn lebih besar dari targetImage.Height/2
                // value yg dh pernah kucoba tuh 50, 25, 10, 5
                int tuning = 5;
                for (int j = -tuning; j <= tuning; j++)
                {
                    targetAscii = Conversion.BinaryStringToAscii(targetBinary.Substring(targetBinary.Length / 2 + targetImage.Width * j - targetImage.Width * 4 / 10, targetImage.Width * 8 / 10));
                    int dist = Comparison.LevenshteinDistance(targetAscii, searchAscii);
                    distanceTemp += (float)((searchAscii.Length - dist) / targetAscii.Length * 100) / (tuning * 2);
                }
                if (similarity == -1)
                {
                    similarity = distanceTemp;
                    notExactIdx = i;
                }
                if (distanceTemp > similarity)
                {
                    similarity = distanceTemp;
                    notExactIdx = i;
                }
            }
        }

        string matchName;
        string matchImageName;
        if (exactIdx != -1)
        {
            matchName = imagePath[exactIdx].Key;
            matchImageName = imagePath[exactIdx].Value;
        }
        else
        {
            matchName = imagePath[notExactIdx].Key;
            matchImageName = imagePath[notExactIdx].Value;
        }

        int minDistance = -1;
        int targetIdx = -1;
        for (int i = 0; i < biodata.Count; i++)
        {
            // System.Console.WriteLine("ngecek biodata ke-" + i);
            if (minDistance == -1)
            {
                minDistance = Regex2.LevenshteinRegex(matchName, biodata[i].Key);
                targetIdx = i;
            }
            if (minDistance > Regex2.LevenshteinRegex(matchName, biodata[i].Key))
            {
                minDistance = Regex2.LevenshteinRegex(matchName, biodata[i].Key);
                targetIdx = i;
            }
        }

        stopwatch.Stop();

        Result result = new Result(biodata[targetIdx].Value, new Bitmap("../../test/" + matchImageName), similarity, (float)stopwatch.ElapsedMilliseconds / 1000);
        return result;
    }

    static public Result BMCalculation(Bitmap targetImage)
    {
        List<KeyValuePair<string, string>> imagePath = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, Biodata>> biodata = new List<KeyValuePair<string, Biodata>>();
        ReadDatabase.DB(imagePath, biodata);
        string targetBinary = Conversion.BMPToBinaryString(targetImage);
        string targetAscii = Conversion.BinaryStringToAscii(targetBinary.Substring(targetBinary.Length / 2, 32)); // panjang biner / 8 = panjang ascii
        string currentDirectory = Directory.GetCurrentDirectory();
        string fileNameWithoutExtension="", extension = "", uppercaseExtension = "", newFileName = "";
        int exactIdx = -1;
        int notExactIdx = -1;
        float similarity = -1;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < imagePath.Count; i++)
        {
            // Separate the file name and extension
            fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath[i].Value);
            extension = Path.GetExtension(imagePath[i].Value);
            uppercaseExtension = extension.ToUpper();

            // Convert the extension to uppercase

            // Combine the file name and the uppercase extension
            newFileName = fileNameWithoutExtension + uppercaseExtension;
            // Determine the current directory
            
            // Set the path to the database file
            string imgPath = Path.Combine(currentDirectory, newFileName);
            System.Console.WriteLine($"{imgPath} {newFileName}");
            Bitmap searchImage = new Bitmap(imgPath);
            if ((double)targetImage.Width / targetImage.Height != (double)searchImage.Width / searchImage.Height)
            {
                continue;
            }
            searchImage = Conversion.Resize(targetImage, searchImage); // normalisasi
            // Console.WriteLine("ngecek sampel ke-" + i);
            string searchAscii = Conversion.BinaryStringToAscii(Conversion.BMPToBinaryString(searchImage));
            int kmpResult = Comparison.BmMatch(searchAscii, targetAscii); // kalo mau bm tinggal ubah jadi bmmatch
            if (kmpResult != -1)
            {
                exactIdx = i;
                similarity = 100;
                break;
            }
        }
        if (exactIdx == -1)
        {
            targetAscii = Conversion.BinaryStringToAscii(targetBinary.Substring(targetBinary.Length / 2 - targetImage.Width * 4 / 10, targetImage.Width * 8 / 10)); // panjang biner / 8 = panjang ascii
            for (int i = 0; i < imagePath.Count; i++)
            {
                Bitmap searchImage = new Bitmap("../../test/" + imagePath[i].Value);
                if ((double)targetImage.Width / targetImage.Height != (double)searchImage.Width / searchImage.Height)
                {
                    continue;
                }
                searchImage = Conversion.Resize(targetImage, searchImage); // normalisasi
                // Console.WriteLine("ngecek sampel ke-" + i);
                string searchBinary = Conversion.BMPToBinaryString(searchImage);
                string searchAscii = Conversion.BinaryStringToAscii(searchBinary);
                float distanceTemp = 0;

                // tuning variabel
                // jgn lebih besar dari targetImage.Height/2
                // value yg dh pernah kucoba tuh 50, 25, 10, 5
                int tuning = 5;
                for (int j = -tuning; j <= tuning; j++)
                {
                    targetAscii = Conversion.BinaryStringToAscii(targetBinary.Substring(targetBinary.Length / 2 + targetImage.Width * j - targetImage.Width * 4 / 10, targetImage.Width * 8 / 10));
                    int dist = Comparison.LevenshteinDistance(targetAscii, searchAscii);
                    distanceTemp += (float)((searchAscii.Length - dist) / targetAscii.Length * 100) / (tuning * 2);
                }
                if (similarity == -1)
                {
                    similarity = distanceTemp;
                    notExactIdx = i;
                }
                if (distanceTemp > similarity)
                {
                    similarity = distanceTemp;
                    notExactIdx = i;
                }
            }
        }

        string matchName;
        string matchImageName;
        if (exactIdx != -1)
        {
            matchName = imagePath[exactIdx].Key;
            matchImageName = imagePath[exactIdx].Value;
        }
        else
        {
            matchName = imagePath[notExactIdx].Key;
            matchImageName = imagePath[notExactIdx].Value;
        }

        int minDistance = -1;
        int targetIdx = -1;
        for (int i = 0; i < biodata.Count; i++)
        {
            // System.Console.WriteLine("ngecek biodata ke-" + i);
            if (minDistance == -1)
            {
                minDistance = Regex2.LevenshteinRegex(matchName, biodata[i].Key);
                targetIdx = i;
            }
            if (minDistance > Regex2.LevenshteinRegex(matchName, biodata[i].Key))
            {
                minDistance = Regex2.LevenshteinRegex(matchName, biodata[i].Key);
                targetIdx = i;
            }
        }

        stopwatch.Stop();
         fileNameWithoutExtension = Path.GetFileNameWithoutExtension(matchImageName);
         extension = Path.GetExtension(matchImageName);

        // Convert the extension to uppercase
         uppercaseExtension = extension.ToUpper();

        // Combine the file name and the uppercase extension
         newFileName = fileNameWithoutExtension + uppercaseExtension;
        string filePath = Path.Combine(currentDirectory, newFileName);
        Result result = new Result(biodata[targetIdx].Value, new Bitmap(filePath), similarity, (float)stopwatch.ElapsedMilliseconds / 1000);
        return result;
    }
}
