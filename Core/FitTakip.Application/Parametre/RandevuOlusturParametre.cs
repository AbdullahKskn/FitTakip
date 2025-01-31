using System;

namespace FitTakip.Application.Parametre;

public class RandevuOlusturParametre
{
    public int UyeId { get; set; }
    public int EgitmenId { get; set; }
    public DateTime Tarih { get; set; }
    public string? Aciklama { get; set; }
}
