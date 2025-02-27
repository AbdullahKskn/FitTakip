using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class SifreDegistirParametreValidator : AbstractValidator<SifreDegistirParametre>
{
    public SifreDegistirParametreValidator()
    {
        RuleFor(r => r.Id).NotEmpty().NotNull().WithMessage("Id Boş Olamaz.");
        RuleFor(r => r.Sifre).NotEmpty().NotNull().WithMessage("Şifre Boş Olamaz.");
        RuleFor(r => r.SifreDogrulama).NotEmpty().NotNull().WithMessage("Şifre Doğrulama Boş Olamaz.");
    }
}
