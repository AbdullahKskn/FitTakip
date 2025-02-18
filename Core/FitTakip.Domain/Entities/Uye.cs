using System;

namespace FitTakip.Domain.Entities;

public class Uye
{
    public int UyeId { get; set; }
    public string Ad { get; set; } = null!;
    public string Soyad { get; set; } = null!;
    public string? TelefonNo { get; set; }
    public int KalanDersSayisi { get; set; }
    public int IsletmeId { get; set; }
    public int EgitmenId { get; set; }
    public bool AktifMi { get; set; }

    public Isletme Isletme { get; set; } = null!;
    public Egitmen Egitmen { get; set; } = null!;
    public ICollection<Randevu> Randevular { get; set; } = null!;
    public ICollection<Olcum> Olcumler { get; set; } = null!;
}
