using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class RandevuOlusturParametreValidator : AbstractValidator<RandevuOlusturParametre>
{
    public RandevuOlusturParametreValidator()
    {
        RuleFor(r => r.UyeId).NotNull().NotEmpty().WithMessage("Üye Id Boş Olamaz");
        RuleFor(r => r.EgitmenId).NotNull().NotEmpty().WithMessage("Eğitmen Id Boş Olamaz");
        RuleFor(r => r.Tarih).NotNull().NotEmpty().WithMessage("Randevu Tarihi Boş Olamaz");
    }
}
