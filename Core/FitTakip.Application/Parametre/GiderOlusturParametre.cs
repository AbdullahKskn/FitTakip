using System;

namespace FitTakip.Application.Parametre;

public class GiderOlusturParametre
{
    public long IsletmeId { get; set; }
    public string Aciklama { get; set; } = null!;
    public DateTime Tarih { get; set; }
    public decimal Tutar { get; set; }
}
