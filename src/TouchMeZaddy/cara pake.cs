// using System;
// using System.Drawing;
// using System.IO;
// using System.Text;
// using System.Diagnostics;
// using System.Threading.Tasks;
// using System.Threading.Tasks.Dataflow;
// using System.Runtime.Intrinsics.X86;
// using System.Runtime.Intrinsics.Arm;
// using System.Reflection;

// partial class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Masukkan nama gambar sampel yang ingin dijadikan referensi");
//         string targetName = Console.ReadLine();
//         Result hasil = MainCalculation.KMPCalculation(targetName);

//         hasil.biodata.printData();
//         System.Console.WriteLine(hasil.picture);
//         System.Console.WriteLine(hasil.similarity);
//         System.Console.WriteLine(hasil.executionTime);

//         hasil = MainCalculation.BMCalculation(targetName);

//         hasil.biodata.printData();
//         System.Console.WriteLine(hasil.picture);
//         System.Console.WriteLine(hasil.similarity);
//         System.Console.WriteLine(hasil.executionTime);
//     }
// }
