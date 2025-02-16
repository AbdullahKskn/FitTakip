using System;

namespace FitTakip.Application.DTOs;

public class GelirDto
{
    public int GelirId { get; set; }
    public int IsletmeId { get; set; }
    public string Aciklama { get; set; } = null!;
    public DateTime Tarih { get; set; }
    public decimal Tutar { get; set; }
}
