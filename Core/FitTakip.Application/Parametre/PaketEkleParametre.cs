using System;

namespace FitTakip.Application.Parametre;

public class PaketEkleParametre
{
    public long IsletmeId { get; set; }
    public string Aciklama { get; set; } = null!;
    public decimal Tutar { get; set; }
    public int DersSayisi { get; set; }
}
