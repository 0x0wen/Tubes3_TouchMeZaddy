using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics.Arm;
using System.Reflection;

partial class Program
{
    // static async Task Main()
    static void Main()
    {
        // Call the asynchronous MainAsync method
        // await MainAsync(new string[] { });
        List<KeyValuePair<string, string>> imagePath = new List<KeyValuePair<string, string>>();
        List<KeyValuePair<string, Biodata>> biodata = new List<KeyValuePair<string, Biodata>>();
        readDB(imagePath, biodata);

        Console.WriteLine("Masukkan id gambar sampel yang ingin dijadikan referensi");
        int id = Convert.ToInt32(Console.ReadLine());
        Bitmap targetImage = new Bitmap("./../../test/sample (" + id + ").bmp");
        string targetBinary = BMPToBinaryString(targetImage);
        string targetAscii = BinaryStringToAscii(targetBinary.Substring(targetBinary.Length/2 - targetImage.Width*4/10, targetImage.Width*8/10)); // panjang biner / 8 = panjang ascii

        int exactIdx = -1;
        int notExactIdx = -1;
        float distance = -1;
        Console.WriteLine("Pencarian dengan KMP dimulai");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < imagePath.Count; i++) {
            Bitmap searchImage = new Bitmap("../../test/" + imagePath[i].Value);
            if ((double)targetImage.Width/targetImage.Height != (double)searchImage.Width/searchImage.Height) {
                continue;
            }
            searchImage = Resize(targetImage, searchImage); // normalisasi
            Console.WriteLine("ngecek sampel ke-" + i);
            string searchAscii = BinaryStringToAscii(BMPToBinaryString(searchImage));
            int result = KmpMatch(searchAscii, targetAscii); // kalo mau bm tinggal ubah jadi bmmatch
            if (result != -1) {
                exactIdx = i;
                break;
            }
        }
        if (exactIdx == -1) {
            Console.WriteLine("Exact match tidak ditemukan");
            Console.WriteLine("Mengulangi pencarian dengan Levenshtein");
            for (int i = 0; i < imagePath.Count; i++) {
                Bitmap searchImage = new Bitmap("../../test/" + imagePath[i].Value);
                if ((double)targetImage.Width/targetImage.Height != (double)searchImage.Width/searchImage.Height) {
                    continue;
                }
                searchImage = Resize(targetImage, searchImage); // normalisasi
                Console.WriteLine("ngecek sampel ke-" + i);
                string searchBinary = BMPToBinaryString(searchImage);
                string searchAscii = BinaryStringToAscii(searchBinary);
                float distanceTemp = 0;

                // tuning variabel
                // jgn lebih besar dari targetImage.Height/2
                // value yg dh pernah kucoba tuh 50, 25, 10, 5
                int tuning = 5;
                for (int j = -tuning; j <= tuning; j++) {
                    targetAscii = BinaryStringToAscii(targetBinary.Substring(targetBinary.Length/2 + targetImage.Width*j - targetImage.Width*4/10, targetImage.Width*8/10));
                    int dist = LevenshteinDistance(targetAscii, searchAscii);
                    distanceTemp += (float)((searchAscii.Length - dist)/targetAscii.Length * 100)/(tuning*2);
                }
                if (distance == -1) {
                    distance = distanceTemp;
                    notExactIdx = i;
                }
                if (distanceTemp > distance) {
                    distance = distanceTemp;
                    notExactIdx = i;
                }
            }
        }
        stopwatch.Stop();

        string matchName;
        if (exactIdx != -1) {
            matchName = imagePath[exactIdx].Key;
            Console.WriteLine("Exact match ditemukan pada gambar dengan id " + exactIdx);
            Console.WriteLine("dengan nama pemilik sidik jari " + matchName);
        }
        else {
            matchName = imagePath[notExactIdx].Key;
            Console.WriteLine("Gambar termirip ditemukan pada gambar dengan id " + notExactIdx + " dan kemiripan " + distance + " persen");
            Console.WriteLine("dengan nama pemilik sidik jari " + matchName);
        }

        System.Console.WriteLine("Mencari nama yang sesuai pada biodata");
        int minDistance = -1;
        int targetIdx = -1;
        for (int i = 0; i < biodata.Count; i++) {
            System.Console.WriteLine("ngecek biodata ke-" + i);
            if (minDistance == -1) {
                minDistance = LevenshteinRegex(matchName, biodata[i].Key);
                targetIdx = i;
            }
            if (minDistance > LevenshteinRegex(matchName, biodata[i].Key)) {
                minDistance = LevenshteinRegex(matchName, biodata[i].Key);
                targetIdx = i;
            }
        }

        System.Console.WriteLine("Berikut data dari pemilik sidik jari yang bernama " + matchName);
        biodata[targetIdx].Value.printData();
        
        Console.WriteLine("Waktu yang dibutuhkan: " + (float)stopwatch.ElapsedMilliseconds/1000 + " detik");
    }
}
