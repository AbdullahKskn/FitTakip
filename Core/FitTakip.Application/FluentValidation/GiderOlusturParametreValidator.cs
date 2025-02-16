using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class GiderOlusturParametreValidator : AbstractValidator<GiderOlusturParametre>
{
    public GiderOlusturParametreValidator()
    {
        RuleFor(r => r.IsletmeId).NotEmpty().NotNull().WithMessage("İşletme Id Boş Olamaz.");
        RuleFor(r => r.Aciklama).NotEmpty().NotNull().WithMessage("Açıklama Boş Olamaz.");
        RuleFor(r => r.Tarih).NotEmpty().NotNull().WithMessage("Tarih Boş Olamaz.");
        RuleFor(r => r.Tutar).NotEmpty().NotNull().WithMessage("Tutar Boş Olamaz.");
    }
}
