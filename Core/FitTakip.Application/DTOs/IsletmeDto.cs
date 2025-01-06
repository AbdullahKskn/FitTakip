using System;

namespace FitTakip.Application.DTOs;

public class IsletmeDto
{
    public int KullaniciId { get; set; }
    public string Ad { get; set; } = null!; // Isletme, Egitmen ve Uye ortak
    public string? TelefonNo { get; set; } // Ortak
    public DateTime? AbonelikSonlanmaTarihi { get; set; } // Isletme için geçerli
    public bool AktifMi { get; set; } // Ortak
    public string Rol { get; set; } = null!;
}
