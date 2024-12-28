using System;

namespace FitTakip.Application.Parametre;

public class AdminGuncelleParametre
{
    public int AdminId { get; set; }
    public string? Ad { get; set; } = null!;
    public string? Soyad { get; set; } = null!;
    public string? TelefonNo { get; set; }
    public string? KullaniciAdi { get; set; } = null!;
    public string? Sifre { get; set; } = null!;
    public DateTime? DogumTarihi { get; set; }
}
