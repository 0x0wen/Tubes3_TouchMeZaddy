using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

public partial class Program
{
    public static async Task MainAsync(string[] args)
    {
        string dbPath = "biodata.db";

        Console.WriteLine($"Database path: {dbPath}.");
        var db = new SQLiteAsyncConnection(dbPath);

        // Create tables
        await db.CreateTableAsync<Biodata>();
        await db.CreateTableAsync<SidikJari>();

        // Insert multiple biodata
        var biodataList = new List<Biodata>
        {
            new Biodata
            {
                NIK = "1234567890123451",
                nama = "John Doe",
                tempat_lahir = "Jakarta",
                tanggal_lahir = new DateTime(1980, 1, 1),
                jenis_kelamin = "Laki-Laki",
                golongan_darah = "O",
                alamat = "Jl. Merdeka No. 1",
                agama = "Islam",
                status_perkawinan = "Menikah",
                pekerjaan = "Programmer",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123452",
                nama = "Jane Doe",
                tempat_lahir = "Bandung",
                tanggal_lahir = new DateTime(1985, 2, 2),
                jenis_kelamin = "Perempuan",
                golongan_darah = "A",
                alamat = "Jl. Sudirman No. 2",
                agama = "Kristen",
                status_perkawinan = "Belum Menikah",
                pekerjaan = "Designer",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123453",
                nama = "Alice Johnson",
                tempat_lahir = "Surabaya",
                tanggal_lahir = new DateTime(1990, 3, 3),
                jenis_kelamin = "Perempuan",
                golongan_darah = "B",
                alamat = "Jl. Pahlawan No. 3",
                agama = "Hindu",
                status_perkawinan = "Menikah",
                pekerjaan = "Teacher",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123454",
                nama = "Bob Smith",
                tempat_lahir = "Medan",
                tanggal_lahir = new DateTime(1975, 4, 4),
                jenis_kelamin = "Laki-Laki",
                golongan_darah = "AB",
                alamat = "Jl. Diponegoro No. 4",
                agama = "Budha",
                status_perkawinan = "Cerai",
                pekerjaan = "Engineer",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123455",
                nama = "Cindy Brown",
                tempat_lahir = "Yogyakarta",
                tanggal_lahir = new DateTime(1983, 5, 5),
                jenis_kelamin = "Perempuan",
                golongan_darah = "O",
                alamat = "Jl. Malioboro No. 5",
                agama = "Katolik",
                status_perkawinan = "Menikah",
                pekerjaan = "Doctor",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123456",
                nama = "David Wilson",
                tempat_lahir = "Semarang",
                tanggal_lahir = new DateTime(1988, 6, 6),
                jenis_kelamin = "Laki-Laki",
                golongan_darah = "A",
                alamat = "Jl. Diponegoro No. 6",
                agama = "Protestan",
                status_perkawinan = "Belum Menikah",
                pekerjaan = "Lawyer",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123457",
                nama = "Eva Martin",
                tempat_lahir = "Bali",
                tanggal_lahir = new DateTime(1992, 7, 7),
                jenis_kelamin = "Perempuan",
                golongan_darah = "B",
                alamat = "Jl. Kuta No. 7",
                agama = "Islam",
                status_perkawinan = "Menikah",
                pekerjaan = "Artist",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123458",
                nama = "Frank Moore",
                tempat_lahir = "Balikpapan",
                tanggal_lahir = new DateTime(1979, 8, 8),
                jenis_kelamin = "Laki-Laki",
                golongan_darah = "AB",
                alamat = "Jl. Sudirman No. 8",
                agama = "Hindu",
                status_perkawinan = "Cerai",
                pekerjaan = "Manager",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123459",
                nama = "Grace Lee",
                tempat_lahir = "Makassar",
                tanggal_lahir = new DateTime(1993, 9, 9),
                jenis_kelamin = "Perempuan",
                golongan_darah = "O",
                alamat = "Jl. Tamalate No. 9",
                agama = "Budha",
                status_perkawinan = "Menikah",
                pekerjaan = "Nurse",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123460",
                nama = "Hank White",
                tempat_lahir = "Padang",
                tanggal_lahir = new DateTime(1981, 10, 10),
                jenis_kelamin = "Laki-Laki",
                golongan_darah = "A",
                alamat = "Jl. Merdeka No. 10",
                agama = "Kristen",
                status_perkawinan = "Belum Menikah",
                pekerjaan = "Technician",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123461",
                nama = "Ivy Green",
                tempat_lahir = "Palembang",
                tanggal_lahir = new DateTime(1991, 11, 11),
                jenis_kelamin = "Perempuan",
                golongan_darah = "B",
                alamat = "Jl. Ampera No. 11",
                agama = "Katolik",
                status_perkawinan = "Menikah",
                pekerjaan = "Scientist",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123462",
                nama = "Jack Black",
                tempat_lahir = "Malang",
                tanggal_lahir = new DateTime(1984, 12, 12),
                jenis_kelamin = "Laki-Laki",
                golongan_darah = "O",
                alamat = "Jl. Soekarno No. 12",
                agama = "Islam",
                status_perkawinan = "Menikah",
                pekerjaan = "Architect",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123463",
                nama = "Kathy Brown",
                tempat_lahir = "Pontianak",
                tanggal_lahir = new DateTime(1987, 1, 13),
                jenis_kelamin = "Perempuan",
                golongan_darah = "A",
                alamat = "Jl. Gajahmada No. 13",
                agama = "Protestan",
                status_perkawinan = "Belum Menikah",
                pekerjaan = "Dentist",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123464",
                nama = "Leo King",
                tempat_lahir = "Banjarmasin",
                tanggal_lahir = new DateTime(1978, 2, 14),
                jenis_kelamin = "Laki-Laki",
                golongan_darah = "B",
                alamat = "Jl. Antasari No. 14",
                agama = "Budha",
                status_perkawinan = "Cerai",
                pekerjaan = "Pilot",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123465",
                nama = "Mia Clark",
                tempat_lahir = "Cirebon",
                tanggal_lahir = new DateTime(1995, 3, 15),
                jenis_kelamin = "Perempuan",
                golongan_darah = "AB",
                alamat = "Jl. Kartini No. 15",
                agama = "Hindu",
                status_perkawinan = "Menikah",
                pekerjaan = "Chef",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123466",
                nama = "Nina Walker",
                tempat_lahir = "Solo",
                tanggal_lahir = new DateTime(1994, 4, 16),
                jenis_kelamin = "Perempuan",
                golongan_darah = "O",
                alamat = "Jl. Slamet Riyadi No. 16",
                agama = "Islam",
                status_perkawinan = "Belum Menikah",
                pekerjaan = "Musician",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123467",
                nama = "Oscar Young",
                tempat_lahir = "Tangerang",
                tanggal_lahir = new DateTime(1989, 5, 17),
                jenis_kelamin = "Laki-Laki",
                golongan_darah = "A",
                alamat = "Jl. Ahmad Yani No. 17",
                agama = "Kristen",
                status_perkawinan = "Menikah",
                pekerjaan = "Photographer",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123468",
                nama = "Paul Harris",
                tempat_lahir = "Cianjur",
                tanggal_lahir = new DateTime(1986, 6, 18),
                jenis_kelamin = "Laki-Laki",
                golongan_darah = "B",
                alamat = "Jl. Siliwangi No. 18",
                agama = "Katolik",
                status_perkawinan = "Cerai",
                pekerjaan = "Journalist",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123469",
                nama = "Quinn Thomas",
                tempat_lahir = "Madiun",
                tanggal_lahir = new DateTime(1996, 7, 19),
                jenis_kelamin = "Perempuan",
                golongan_darah = "AB",
                alamat = "Jl. Pahlawan No. 19",
                agama = "Budha",
                status_perkawinan = "Belum Menikah",
                pekerjaan = "Writer",
                kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123470",
                nama = "Rachel Scott",
                tempat_lahir = "Jember",
                tanggal_lahir = new DateTime(1990, 8, 20),
                jenis_kelamin = "Perempuan",
                golongan_darah = "O",
                alamat = "Jl. Jawa No. 20",
                agama = "Islam",
                status_perkawinan = "Menikah",
                pekerjaan = "Engineer",
                kewarganegaraan = "Indonesia"
            }
        };

        await InsertMultipleBiodata(db, biodataList);

        var sidikJariList = new List<SidikJari>
        {
            new SidikJari
            {
                berkas_citra = "./../../test/sample (1).bmp",
                nama = "John Doe"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (2).bmp",
                nama = "Jane Doe"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (3).bmp",
                nama = "Alice Johnson"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (4).bmp",
                nama = "Bob Smith"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (5).bmp",
                nama = "Cindy Brown"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (6).bmp",
                nama = "David Wilson"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (7).bmp",
                nama = "Eva Martin"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (8).bmp",
                nama = "Frank Moore"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (9).bmp",
                nama = "Grace Lee"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (10).bmp",
                nama = "Hank White"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (11).bmp",
                nama = "Ivy Green"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (12).bmp",
                nama = "Jack Black"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (13).bmp",
                nama = "Kathy Brown"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (14).bmp",
                nama = "Leo King"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (15).bmp",
                nama = "Mia Clark"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (16).bmp",
                nama = "Nina Walker"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (17).bmp",
                nama = "Oscar Young"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (18).bmp",
                nama = "Paul Harris"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (19).bmp",
                nama = "Quinn Thomas"
            },
            new SidikJari
            {
                berkas_citra = "./../../test/sample (20).bmp",
                nama = "Rachel Scott"
            }
        };

        await InsertMultipleSidikJari(db, sidikJariList);

        // Query and print Biodata
        var retrievedBiodataList = await db.Table<Biodata>().ToListAsync();
        foreach (var b in retrievedBiodataList)
        {
            Console.WriteLine($"NIK: {b.NIK}, nama: {b.nama}");
        }

        // Query and print SidikJari
        var retrievedSidikJariList = await db.Table<SidikJari>().ToListAsync();
        foreach (var s in retrievedSidikJariList)
        {
            Console.WriteLine($"nama: {s.nama}, Berkas Citra: {s.berkas_citra}");
        }
    }

    public static async Task InsertMultipleBiodata(SQLiteAsyncConnection db, List<Biodata> biodataList)
    {
        foreach (var biodata in biodataList)
        {
            await db.InsertAsync(biodata);
        }
    }

    public static async Task InsertMultipleSidikJari(SQLiteAsyncConnection db, List<SidikJari> sidikJariList)
    {
        foreach (var sidikJari in sidikJariList)
        {
            await db.InsertAsync(sidikJari);
        }
    }
}
