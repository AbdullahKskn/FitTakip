using System;

namespace FitTakip.Domain.Entities;

public class Olcum
{
    public long OlcumId { get; set; }
    public long UyeId { get; set; }
    public DateTime Tarih { get; set; }
    public int Boy { get; set; }
    public decimal Kilo { get; set; }
    public int Omuz { get; set; }
    public int Gogus { get; set; }
    public int SagKol { get; set; }
    public int SolKol { get; set; }
    public int Bel { get; set; }
    public int Kalca { get; set; }
    public int SagBacak { get; set; }
    public int SolBacak { get; set; }

    public Uye Uye { get; set; } = null!;
}
