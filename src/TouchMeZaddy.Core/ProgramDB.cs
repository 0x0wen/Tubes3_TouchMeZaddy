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
                Nama = "John Doe",
                TempatLahir = "Jakarta",
                TanggalLahir = new DateTime(1980, 1, 1),
                JenisKelamin = "Laki-Laki",
                GolonganDarah = "O",
                Alamat = "Jl. Merdeka No. 1",
                Agama = "Islam",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Programmer",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123452",
                Nama = "Jane Doe",
                TempatLahir = "Bandung",
                TanggalLahir = new DateTime(1985, 2, 2),
                JenisKelamin = "Perempuan",
                GolonganDarah = "A",
                Alamat = "Jl. Sudirman No. 2",
                Agama = "Kristen",
                StatusPerkawinan = "Belum Menikah",
                Pekerjaan = "Designer",
                Kewarganegaraan = "Indonesia"
            },
            // Add more unique data here...
            new Biodata
            {
                NIK = "1234567890123453",
                Nama = "Alice Johnson",
                TempatLahir = "Surabaya",
                TanggalLahir = new DateTime(1990, 3, 3),
                JenisKelamin = "Perempuan",
                GolonganDarah = "B",
                Alamat = "Jl. Pahlawan No. 3",
                Agama = "Hindu",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Teacher",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123454",
                Nama = "Bob Smith",
                TempatLahir = "Medan",
                TanggalLahir = new DateTime(1975, 4, 4),
                JenisKelamin = "Laki-Laki",
                GolonganDarah = "AB",
                Alamat = "Jl. Diponegoro No. 4",
                Agama = "Budha",
                StatusPerkawinan = "Cerai",
                Pekerjaan = "Engineer",
                Kewarganegaraan = "Indonesia"
            },
            // More unique sample data...
            new Biodata
            {
                NIK = "1234567890123455",
                Nama = "Cindy Brown",
                TempatLahir = "Yogyakarta",
                TanggalLahir = new DateTime(1983, 5, 5),
                JenisKelamin = "Perempuan",
                GolonganDarah = "O",
                Alamat = "Jl. Malioboro No. 5",
                Agama = "Katolik",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Doctor",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123456",
                Nama = "David Wilson",
                TempatLahir = "Semarang",
                TanggalLahir = new DateTime(1988, 6, 6),
                JenisKelamin = "Laki-Laki",
                GolonganDarah = "A",
                Alamat = "Jl. Diponegoro No. 6",
                Agama = "Protestan",
                StatusPerkawinan = "Belum Menikah",
                Pekerjaan = "Lawyer",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123457",
                Nama = "Eva Martin",
                TempatLahir = "Bali",
                TanggalLahir = new DateTime(1992, 7, 7),
                JenisKelamin = "Perempuan",
                GolonganDarah = "B",
                Alamat = "Jl. Kuta No. 7",
                Agama = "Islam",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Artist",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123458",
                Nama = "Frank Moore",
                TempatLahir = "Balikpapan",
                TanggalLahir = new DateTime(1979, 8, 8),
                JenisKelamin = "Laki-Laki",
                GolonganDarah = "AB",
                Alamat = "Jl. Sudirman No. 8",
                Agama = "Hindu",
                StatusPerkawinan = "Cerai",
                Pekerjaan = "Manager",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123459",
                Nama = "Grace Lee",
                TempatLahir = "Makassar",
                TanggalLahir = new DateTime(1993, 9, 9),
                JenisKelamin = "Perempuan",
                GolonganDarah = "O",
                Alamat = "Jl. Tamalate No. 9",
                Agama = "Budha",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Nurse",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123460",
                Nama = "Hank White",
                TempatLahir = "Padang",
                TanggalLahir = new DateTime(1981, 10, 10),
                JenisKelamin = "Laki-Laki",
                GolonganDarah = "A",
                Alamat = "Jl. Merdeka No. 10",
                Agama = "Kristen",
                StatusPerkawinan = "Belum Menikah",
                Pekerjaan = "Technician",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123461",
                Nama = "Ivy Green",
                TempatLahir = "Palembang",
                TanggalLahir = new DateTime(1991, 11, 11),
                JenisKelamin = "Perempuan",
                GolonganDarah = "B",
                Alamat = "Jl. Ampera No. 11",
                Agama = "Katolik",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Scientist",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123462",
                Nama = "Jack Black",
                TempatLahir = "Malang",
                TanggalLahir = new DateTime(1984, 12, 12),
                JenisKelamin = "Laki-Laki",
                GolonganDarah = "O",
                Alamat = "Jl. Soekarno No. 12",
                Agama = "Islam",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Architect",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123463",
                Nama = "Kathy Brown",
                TempatLahir = "Pontianak",
                TanggalLahir = new DateTime(1987, 1, 13),
                JenisKelamin = "Perempuan",
                GolonganDarah = "A",
                Alamat = "Jl. Gajahmada No. 13",
                Agama = "Protestan",
                StatusPerkawinan = "Belum Menikah",
                Pekerjaan = "Dentist",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123464",
                Nama = "Leo King",
                TempatLahir = "Banjarmasin",
                TanggalLahir = new DateTime(1978, 2, 14),
                JenisKelamin = "Laki-Laki",
                GolonganDarah = "B",
                Alamat = "Jl. Antasari No. 14",
                Agama = "Budha",
                StatusPerkawinan = "Cerai",
                Pekerjaan = "Pilot",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123465",
                Nama = "Mia Clark",
                TempatLahir = "Cirebon",
                TanggalLahir = new DateTime(1995, 3, 15),
                JenisKelamin = "Perempuan",
                GolonganDarah = "AB",
                Alamat = "Jl. Kartini No. 15",
                Agama = "Hindu",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Chef",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123466",
                Nama = "Nina Walker",
                TempatLahir = "Solo",
                TanggalLahir = new DateTime(1994, 4, 16),
                JenisKelamin = "Perempuan",
                GolonganDarah = "O",
                Alamat = "Jl. Slamet Riyadi No. 16",
                Agama = "Islam",
                StatusPerkawinan = "Belum Menikah",
                Pekerjaan = "Musician",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123467",
                Nama = "Oscar Young",
                TempatLahir = "Tangerang",
                TanggalLahir = new DateTime(1989, 5, 17),
                JenisKelamin = "Laki-Laki",
                GolonganDarah = "A",
                Alamat = "Jl. Ahmad Yani No. 17",
                Agama = "Kristen",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Photographer",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123468",
                Nama = "Paul Harris",
                TempatLahir = "Cianjur",
                TanggalLahir = new DateTime(1986, 6, 18),
                JenisKelamin = "Laki-Laki",
                GolonganDarah = "B",
                Alamat = "Jl. Siliwangi No. 18",
                Agama = "Katolik",
                StatusPerkawinan = "Cerai",
                Pekerjaan = "Journalist",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123469",
                Nama = "Quinn Thomas",
                TempatLahir = "Madiun",
                TanggalLahir = new DateTime(1996, 7, 19),
                JenisKelamin = "Perempuan",
                GolonganDarah = "AB",
                Alamat = "Jl. Pahlawan No. 19",
                Agama = "Budha",
                StatusPerkawinan = "Belum Menikah",
                Pekerjaan = "Writer",
                Kewarganegaraan = "Indonesia"
            },
            new Biodata
            {
                NIK = "1234567890123470",
                Nama = "Rachel Scott",
                TempatLahir = "Jember",
                TanggalLahir = new DateTime(1990, 8, 20),
                JenisKelamin = "Perempuan",
                GolonganDarah = "O",
                Alamat = "Jl. Jawa No. 20",
                Agama = "Islam",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Engineer",
                Kewarganegaraan = "Indonesia"
            }
        };

        await InsertMultipleBiodata(db, biodataList);

        // Insert multiple sidik jari
        var sidikJariList = new List<SidikJari>
        {
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint1/image",
                Nama = "John Doe"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint2/image",
                Nama = "Jane Doe"
            },
            // Add more unique data here...
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint3/image",
                Nama = "Alice Johnson"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint4/image",
                Nama = "Bob Smith"
            },
            // More unique sample data...
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint5/image",
                Nama = "Cindy Brown"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint6/image",
                Nama = "David Wilson"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint7/image",
                Nama = "Eva Martin"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint8/image",
                Nama = "Frank Moore"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint9/image",
                Nama = "Grace Lee"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint10/image",
                Nama = "Hank White"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint11/image",
                Nama = "Ivy Green"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint12/image",
                Nama = "Jack Black"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint13/image",
                Nama = "Kathy Brown"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint14/image",
                Nama = "Leo King"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint15/image",
                Nama = "Mia Clark"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint16/image",
                Nama = "Nina Walker"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint17/image",
                Nama = "Oscar Young"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint18/image",
                Nama = "Paul Harris"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint19/image",
                Nama = "Quinn Thomas"
            },
            new SidikJari
            {
                BerkasCitra = "path/to/fingerprint20/image",
                Nama = "Rachel Scott"
            }
        };

        await InsertMultipleSidikJari(db, sidikJariList);

        // Query and print Biodata
        var retrievedBiodataList = await db.Table<Biodata>().ToListAsync();
        foreach (var b in retrievedBiodataList)
        {
            Console.WriteLine($"NIK: {b.NIK}, Nama: {b.Nama}");
        }

        // Query and print SidikJari
        var retrievedSidikJariList = await db.Table<SidikJari>().ToListAsync();
        foreach (var s in retrievedSidikJariList)
        {
            Console.WriteLine($"Nama: {s.Nama}, Berkas Citra: {s.BerkasCitra}");
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
