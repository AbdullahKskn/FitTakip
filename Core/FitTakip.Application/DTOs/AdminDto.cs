using System;

namespace FitTakip.Application.DTOs;

public class AdminDto
{
    public int KullaniciId { get; set; }
    public string Ad { get; set; } = null!; // Isletme, Egitmen ve Uye ortak
    public string? Soyad { get; set; } // Egitmen ve Uye için geçerli
    public string? TelefonNo { get; set; } // Ortak
    public DateTime? DogumTarihi { get; set; } // Uye için geçerli
    public string Rol { get; set; } = null!;
    public string Token { get; set; } = null!;
}
