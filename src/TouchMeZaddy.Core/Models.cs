using System;
using SQLite;

[Table("Biodata")]
public class Biodata
{
    [PrimaryKey]
    [MaxLength(16)]
    public string NIK { get; set; }
    
    [MaxLength(100)]
    public string Nama { get; set; }
    
    [MaxLength(50)]
    public string TempatLahir { get; set; }
    
    public DateTime? TanggalLahir { get; set; }
    
    [MaxLength(10)]
    public string JenisKelamin { get; set; }
    
    [MaxLength(5)]
    public string GolonganDarah { get; set; }
    
    [MaxLength(255)]
    public string Alamat { get; set; }
    
    [MaxLength(50)]
    public string Agama { get; set; }
    
    [MaxLength(20)]
    public string StatusPerkawinan { get; set; }
    
    [MaxLength(100)]
    public string Pekerjaan { get; set; }
    
    [MaxLength(50)]
    public string Kewarganegaraan { get; set; }
}

[Table("SidikJari")]
public class SidikJari
{
    public string BerkasCitra { get; set; }
    
    [MaxLength(100)]
    public string Nama { get; set; }
}