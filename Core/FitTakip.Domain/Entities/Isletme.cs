using System;

namespace FitTakip.Domain.Entities;

public class Isletme
{
    public int IsletmeId { get; set; }
    public string Ad { get; set; } = null!;
    public string TelefonNo { get; set; } = null!;
    public string KullaniciAdi { get; set; } = null!;
    public string SifreKarmasi { get; set; } = null!;
    public DateTime AbonelikSonlanmaTarihi { get; set; }
    public bool AktifMi { get; set; }

    public ICollection<Egitmen> Egitmenler { get; set; } = null!;
    public ICollection<Uye> Uyeler { get; set; } = null!;
}
