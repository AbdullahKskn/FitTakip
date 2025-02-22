using System;

namespace FitTakip.Application.Parametre;

public class UyeOlusturParametre
{
    public string Ad { get; set; } = null!;
    public string Soyad { get; set; } = null!; 
    public string? TelefonNo { get; set; }
    public int PaketId { get; set; } 
    public int IsletmeId { get; set; } 
    public int EgitmenId { get; set; } 
}
