using System;

namespace FitTakip.Domain.Entities;

public class Randevu
{
    public long RandevuId { get; set; }
    public long UyeId { get; set; }
    public long EgitmenId { get; set; }
    public DateTime Tarih { get; set; }
    public string? Aciklama { get; set; }

    public Uye Uye { get; set; } = null!;
    public Egitmen Egitmen { get; set; } = null!;
}
