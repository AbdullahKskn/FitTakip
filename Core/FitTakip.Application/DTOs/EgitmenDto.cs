using System;

namespace FitTakip.Application.DTOs;

public class EgitmenDto
{
    public int EgitmenId { get; set; }
    public string Ad { get; set; } = null!;
    public string Soyad { get; set; } = null!;
    public string? TelefonNo { get; set; }
    public int IsletmeId { get; set; }
    public bool AktifMi { get; set; }
    public string Rol { get; set; } = null!;
    public string Token { get; set; } = null!;
}
