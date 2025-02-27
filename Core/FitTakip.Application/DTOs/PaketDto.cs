using System;

namespace FitTakip.Application.DTOs;

public class PaketDto
{
    public long PaketId { get; set; }
    public long IsletmeId { get; set; }
    public string Aciklama { get; set; } = null!;
    public decimal Tutar { get; set; }
    public int DersSayisi { get; set; }
}
