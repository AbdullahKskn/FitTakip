using System;

namespace FitTakip.Application.Parametre;

public class SifreDegistirParametre
{
    public long Id { get; set; }
    public string Sifre { get; set; } = null!;
    public string SifreDogrulama { get; set; } = null!;
}
