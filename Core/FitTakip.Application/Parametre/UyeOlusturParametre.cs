using System;

namespace FitTakip.Application.Parametre;

public class UyeOlusturParametre
{
    public string Ad { get; set; } = null!; // Isletme, Egitmen ve Uye ortak
    public string Soyad { get; set; } = null!;  // Egitmen ve Uye için geçerli
    public string? TelefonNo { get; set; } // Ortak
    public string KullaniciAdi { get; set; } = null!; // Ortak
    public string Sifre { get; set; } = null!; // Ortak
    public int DersSayisi { get; set; } // Uye için geçerli
    public DateTime? DogumTarihi { get; set; } // Uye için geçerli
    public int IsletmeId { get; set; } // Egitmen ve Uye için geçerli
    public int EgitmenId { get; set; } // Uye için geçerli
}
