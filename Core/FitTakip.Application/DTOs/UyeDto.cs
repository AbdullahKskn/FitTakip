using System;

namespace FitTakip.Application.DTOs;

public class UyeDto
{
    public int UyeId { get; set; }
    public string Ad { get; set; } = null!;
    public string? Soyad { get; set; }
    public string? TelefonNo { get; set; }
    public int? KalanDersSayisi { get; set; }
    public int? IsletmeId { get; set; }
    public int? EgitmenId { get; set; }
    public string? EgitmenAdı { get; set; }
    public bool AktifMi { get; set; }
}
