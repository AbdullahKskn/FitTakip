using System;

namespace FitTakip.Application.Parametre;

public class UyeGuncelleParametre
{
    public int UyeId { get; set; }
    public string? Ad { get; set; } = null!;
    public string? Soyad { get; set; } = null!;
    public string? TelefonNo { get; set; }
    public int? DersSayisi { get; set; }
}
