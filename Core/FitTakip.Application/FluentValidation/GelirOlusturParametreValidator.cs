using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class GelirOlusturParametreValidator : AbstractValidator<GelirOlusturParametre>
{
    public GelirOlusturParametreValidator()
    {
        RuleFor(r => r.IsletmeId).NotNull().NotEmpty().WithMessage("İşletme Id Boş Olamaz.");
        RuleFor(r => r.Aciklama).NotNull().NotEmpty().WithMessage("Gelir Açıklaması Boş Olamaz.");
        RuleFor(r => r.Tarih).NotNull().NotEmpty().WithMessage("Gelir Tarihi Boş Olamaz.");
        RuleFor(r => r.Tutar).NotNull().NotEmpty().WithMessage("Fiyat Boş Olamaz.");
    }
}
