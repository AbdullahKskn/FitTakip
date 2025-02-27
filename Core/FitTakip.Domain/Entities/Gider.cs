using System;

namespace FitTakip.Domain.Entities;

public class Gider
{
    public long GiderId { get; set; }
    public long IsletmeId { get; set; }
    public string Aciklama { get; set; } = null!;
    public DateTime Tarih { get; set; }
    public decimal Tutar { get; set; }
}
