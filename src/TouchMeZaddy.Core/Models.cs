using System;
using System.ComponentModel;
using SQLite;

[Table("Biodata")]
public class Biodata
{
    [PrimaryKey]
    [MaxLength(16)]
    [NotNull]
    public string NIK { get; set; }
    
    [MaxLength(100)]
    [DefaultValue(null)]
    public string Nama { get; set; }
    
    [MaxLength(50)]
    [DefaultValue(null)]
    public string TempatLahir { get; set; }
    
    [DefaultValue(null)]
    public DateTime? TanggalLahir { get; set; }
    
    [MaxLength(10)]
    [DefaultValue(null)]
    public string JenisKelamin { get; set; }
    
    [MaxLength(5)]
    [DefaultValue(null)]
    public string GolonganDarah { get; set; }
    
    [MaxLength(255)]
    [DefaultValue(null)]
    public string Alamat { get; set; }
    
    [MaxLength(50)]
    [DefaultValue(null)]
    public string Agama { get; set; }
    
    [MaxLength(20)]
    [DefaultValue(null)]
    public string StatusPerkawinan { get; set; }
    
    [MaxLength(100)]
    [DefaultValue(null)]
    public string Pekerjaan { get; set; }
    
    [MaxLength(50)]
    [DefaultValue(null)]
    public string Kewarganegaraan { get; set; }
}

[Table("SidikJari")]
public class SidikJari
{
    public string BerkasCitra { get; set; }
    
    [MaxLength(100)]
    [DefaultValue(null)]
    public string Nama { get; set; }
}