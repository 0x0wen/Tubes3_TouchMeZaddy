using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

class Biodata
{
    public string NIK;
    public string nama;
    public string tempat_lahir;
    public string tanggal_lahir;
    public string jenis_kelamin;
    public string golongan_darah;
    public string alamat;
    public string agama;
    public string status_perkawinan;
    public string pekerjaan;
    public string kewarganegaraan;

    public Biodata(string NIK, string nama, string tempat_lahir, string tanggal_lahir, string jenis_kelamin, string golongan_darah, string alamat, string agama, string status_perkawinan, string pekerjaan, string kewarganegaraan) {
        this.NIK = NIK;
        this.nama = nama;
        this.tempat_lahir = tempat_lahir;
        this.tanggal_lahir = tanggal_lahir;
        this.jenis_kelamin = jenis_kelamin;
        this.golongan_darah = golongan_darah;
        this.alamat = alamat;
        this.agama = agama;
        this.status_perkawinan = status_perkawinan;
        this.pekerjaan = pekerjaan;
        this.kewarganegaraan = kewarganegaraan;
    }

    public void printData() {
        Console.WriteLine(NIK);
        Console.WriteLine(tempat_lahir);
        Console.WriteLine(tanggal_lahir);
        Console.WriteLine(jenis_kelamin);
        Console.WriteLine(golongan_darah);
        Console.WriteLine(alamat);
        Console.WriteLine(agama);
        Console.WriteLine(status_perkawinan);
        Console.WriteLine(pekerjaan);
        Console.WriteLine(kewarganegaraan);
    }
}
