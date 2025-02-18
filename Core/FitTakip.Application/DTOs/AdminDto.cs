using System;

namespace FitTakip.Application.DTOs;

public class AdminDto
{
    public int AdminId { get; set; }
    public string Ad { get; set; } = null!;
    public string Soyad { get; set; } = null!;
    public string Rol { get; set; } = null!;
    public string Token { get; set; } = null!;
}
