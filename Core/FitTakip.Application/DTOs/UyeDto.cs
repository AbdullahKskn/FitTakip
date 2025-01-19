using System;

namespace FitTakip.Application.DTOs;

public class UyeDto
{
    public int KullaniciId { get; set; }
    public string Ad { get; set; } = null!; // Isletme, Egitmen ve Uye ortak
    public string? Soyad { get; set; } // Egitmen ve Uye için geçerli
    public string? TelefonNo { get; set; } // Ortak
    public int? KalanDersSayisi { get; set; } // Uye için geçerli
    public DateTime? DogumTarihi { get; set; } // Uye için geçerli
    public int? IsletmeId { get; set; } // Egitmen ve Uye için geçerli
    public int? EgitmenId { get; set; } // Uye için geçerli
    public string? EgitmenAdı { get; set; } // Uye için geçerli
    public bool AktifMi { get; set; } // Ortak
    public string Rol { get; set; } = null!;
    public string Token { get; set; } = null!;
}
