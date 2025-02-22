using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class PaketEkleParametreValidator : AbstractValidator<PaketEkleParametre>
{
    public PaketEkleParametreValidator()
    {
        RuleFor(r => r.IsletmeId).NotEmpty().NotNull().WithMessage("İşletme Id Boş Olamaz.");
        RuleFor(r => r.Aciklama).NotEmpty().NotNull().WithMessage("Paket Açıklaması Boş Olamaz.");
        RuleFor(r => r.Tutar).NotEmpty().NotNull().WithMessage("Tutar Bilgisi Boş Olamaz.");
        RuleFor(r => r.DersSayisi).NotEmpty().NotNull().WithMessage("Ders Sayısı Boş Olamaz.");
    }
}
