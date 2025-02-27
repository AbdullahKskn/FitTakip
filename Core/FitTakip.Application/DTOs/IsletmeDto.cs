using System;

namespace FitTakip.Application.DTOs;

public class IsletmeDto
{
    public long IsletmeId { get; set; }
    public string Ad { get; set; } = null!;
    public string TelefonNo { get; set; } = null!;
    public DateTime AbonelikSonlanmaTarihi { get; set; }
    public bool AktifMi { get; set; }
    public string Rol { get; set; } = null!;
    public string Token { get; set; } = null!;
}
