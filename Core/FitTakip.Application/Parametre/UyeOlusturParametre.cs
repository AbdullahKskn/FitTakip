using System;

namespace FitTakip.Application.Parametre;

public class UyeOlusturParametre
{
    public string Ad { get; set; } = null!;
    public string Soyad { get; set; } = null!; 
    public string? TelefonNo { get; set; }
    public long PaketId { get; set; } 
    public long IsletmeId { get; set; } 
    public long EgitmenId { get; set; } 
}
