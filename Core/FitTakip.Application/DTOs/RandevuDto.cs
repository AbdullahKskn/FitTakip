using System;

namespace FitTakip.Application.DTOs;

public class RandevuDto
{
    public long RandevuId { get; set; }
    public long UyeId { get; set; }
    public string? UyeAdi { get; set; }
    public long EgitmenId { get; set; }
    public string? EgitmenAdi { get; set; }
    public DateTime Tarih { get; set; }
    public string? Aciklama { get; set; }
}
