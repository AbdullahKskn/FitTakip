using System;

namespace FitTakip.Application.DTOs;

public class PaketDto
{
    public int PaketId { get; set; }
    public int IsletmeId { get; set; }
    public string Aciklama { get; set; } = null!;
    public decimal Tutar { get; set; }
    public int DersSayisi { get; set; }
}
