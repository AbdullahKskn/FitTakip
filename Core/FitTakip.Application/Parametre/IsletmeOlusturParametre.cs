using System;

namespace FitTakip.Application.Parametre;

public class IsletmeOlusturParametre
{
    public string Ad { get; set; } = null!;
    public string TelefonNo { get; set; } = null!;
    public string KullaniciAdi { get; set; } = null!;
    public string Sifre { get; set; } = null!;
    public DateTime AbonelikSonlanmaTarihi { get; set; }
}
