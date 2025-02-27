using System;

namespace FitTakip.Application.Parametre;

public class EgitmenOlusturParametre
{
    public string Ad { get; set; } = null!; // Isletme, Egitmen ve Uye ortak
    public string Soyad { get; set; } = null!; // Egitmen ve Uye için geçerli
    public string? TelefonNo { get; set; } // Ortak
    public string KullaniciAdi { get; set; } = null!; // Ortak
    public string Sifre { get; set; } = null!; // Ortak
    public long IsletmeId { get; set; } // Egitmen ve Uye için geçerli
}
