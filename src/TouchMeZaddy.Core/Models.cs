// using System;
// using System.ComponentModel;
// using SQLite;

// [Table("biodata")]
// public class Biodata
// {
//     [PrimaryKey]
//     [MaxLength(16)]
//     [NotNull]
//     public string NIK { get; set; }
    
//     [MaxLength(100)]
//     [DefaultValue(null)]
//     public string nama { get; set; }
    
//     [MaxLength(50)]
//     [DefaultValue(null)]
//     public string tempat_lahir { get; set; }
    
//     [DefaultValue(null)]
//     public DateTime? tanggal_lahir { get; set; }
    
//     [MaxLength(10)]
//     [DefaultValue(null)]
//     public string jenis_kelamin { get; set; }
    
//     [MaxLength(5)]
//     [DefaultValue(null)]
//     public string golongan_darah { get; set; }
    
//     [MaxLength(255)]
//     [DefaultValue(null)]
//     public string alamat { get; set; }
    
//     [MaxLength(50)]
//     [DefaultValue(null)]
//     public string agama { get; set; }
    
//     [MaxLength(20)]
//     [DefaultValue(null)]
//     public string status_perkawinan { get; set; }
    
//     [MaxLength(100)]
//     [DefaultValue(null)]
//     public string pekerjaan { get; set; }
    
//     [MaxLength(50)]
//     [DefaultValue(null)]
//     public string kewarganegaraan { get; set; }
// }

// [Table("sidik_jari")]
// public class SidikJari
// {
//     public string berkas_citra { get; set; }
    
//     [MaxLength(100)]
//     [DefaultValue(null)]
//     public string nama { get; set; }
// }