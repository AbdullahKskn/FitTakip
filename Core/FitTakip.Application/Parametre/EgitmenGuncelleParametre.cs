using System;

namespace FitTakip.Application.Parametre;

public class EgitmenGuncelleParametre
{
    public long EgitmenId { get; set; }
    public string? Ad { get; set; }  // Isletme, Egitmen ve Uye ortak
    public string? Soyad { get; set; }  // Egitmen ve Uye için geçerli
    public string? TelefonNo { get; set; } // Ortak
    public string? KullaniciAdi { get; set; }  // Ortak
    public string? Sifre { get; set; }  // Ortak
}
