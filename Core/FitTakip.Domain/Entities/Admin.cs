using System;

namespace FitTakip.Domain.Entities;

public class Admin
{
    public int AdminId { get; set; }
    public string Ad { get; set; } = null!;
    public string Soyad { get; set; } = null!;
    public string KullaniciAdi { get; set; } = null!;
    public string SifreKarmasi { get; set; } = null!;
    public bool AktifMi { get; set; }
}
