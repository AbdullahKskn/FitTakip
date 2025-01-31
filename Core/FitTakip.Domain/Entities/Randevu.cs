using System;

namespace FitTakip.Domain.Entities;

public class Randevu
{
    public long RandevuId { get; set; }
    public int UyeId { get; set; }
    public int EgitmenId { get; set; }
    public DateTime Tarih { get; set; }
    public string? Aciklama { get; set; }

    public Kullanici Uye { get; set; } = null!;
    public Kullanici Egitmen { get; set; } = null!;
}
