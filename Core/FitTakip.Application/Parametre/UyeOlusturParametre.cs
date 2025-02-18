using System;

namespace FitTakip.Application.Parametre;

public class UyeOlusturParametre
{
    public string Ad { get; set; } = null!;
    public string Soyad { get; set; } = null!;  // Egitmen ve Uye için geçerli
    public string? TelefonNo { get; set; } // Ortak
    public int DersSayisi { get; set; } // Uye için geçerli
    public int IsletmeId { get; set; } // Egitmen ve Uye için geçerli
    public int EgitmenId { get; set; } // Uye için geçerli
}
