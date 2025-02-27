using System;

namespace FitTakip.Application.Parametre;

public class RandevuOlusturParametre
{
    public long UyeId { get; set; }
    public long EgitmenId { get; set; }
    public DateTime Tarih { get; set; }
    public string? Aciklama { get; set; }
}
