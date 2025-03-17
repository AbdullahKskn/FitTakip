using System;

namespace FitTakip.Domain.Entities;

public class Paket
{
    public long PaketId { get; set; }
    public long IsletmeId { get; set; }
    public string Aciklama { get; set; } = null!;
    public decimal Tutar { get; set; }
    public int DersSayisi { get; set; }
    public bool AktifMi { get; set; }

    public Isletme Isletme { get; set; } = null!;
    public ICollection<Uye> Uyeler { get; set; } = null!;
    public ICollection<Randevu> Randevular { get; set; } = null!;
}
