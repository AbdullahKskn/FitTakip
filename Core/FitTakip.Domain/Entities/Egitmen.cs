using System;

namespace FitTakip.Domain.Entities;

public class Egitmen
{
    public long EgitmenId { get; set; }
    public string Ad { get; set; } = null!;
    public string Soyad { get; set; } = null!;
    public string? TelefonNo { get; set; }
    public string KullaniciAdi { get; set; } = null!;
    public string SifreKarmasi { get; set; } = null!;
    public long IsletmeId { get; set; }
    public bool AktifMi { get; set; }

    public Isletme Isletme { get; set; } = null!;
    public ICollection<Uye> Uyeler { get; set; } = null!;
    public ICollection<Randevu> Randevular { get; set; } = null!;

}
