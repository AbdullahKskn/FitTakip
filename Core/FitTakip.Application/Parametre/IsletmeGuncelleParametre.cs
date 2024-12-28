using System;

namespace FitTakip.Application.Parametre;

public class IsletmeGuncelleParametre
{
    public int IsletmeId { get; set; }
    public string? Ad { get; set; }
    public string? TelefonNo { get; set; }
    public string? KullaniciAdi { get; set; }
    public string? Sifre { get; set; }
    public DateTime? AbonelikSonlanmaTarihi { get; set; }
}
