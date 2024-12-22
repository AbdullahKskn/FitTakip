using System;
using FitTakip.Domain.Enum;

namespace FitTakip.Domain.Entities;

public class Kullanici
{
    public int KullaniciId { get; set; }
    public string Ad { get; set; } = null!; // Isletme, Egitmen ve Uye ortak
    public string? Soyad { get; set; } // Egitmen ve Uye için geçerli
    public string? TelefonNo { get; set; } // Ortak
    public string KullaniciAdi { get; set; } = null!; // Ortak
    public string SifreKarmasi { get; set; } = null!; // Ortak
    public int? KalanDersSayisi { get; set; } // Uye için geçerli
    public DateTime? DogumTarihi { get; set; } // Uye için geçerli
    public DateTime? AbonelikSonlanmaTarihi { get; set; } // Isletme için geçerli
    public int? IsletmeId { get; set; } // Egitmen ve Uye için geçerli
    public int? EgitmenId { get; set; } // Uye için geçerli
    public Statu Statu { get; set; }
    public bool AktifMi { get; set; } // Ortak

    public ICollection<Randevu> UyeRandevulari { get; set; } = new List<Randevu>(); 
    public ICollection<Randevu> EgitmenRandevulari { get; set; } = new List<Randevu>();
    public ICollection<Olcum> UyeOlcumleri { get; set; } = new List<Olcum>();
}
