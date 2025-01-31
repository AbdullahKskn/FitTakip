using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class UyeGuncelleParametreValidator : AbstractValidator<UyeGuncelleParametre>
{
    public UyeGuncelleParametreValidator()
    {
        RuleFor(r => r.UyeId).NotNull().NotEmpty().WithMessage("Üye Id Boş Olamaz.");
    }
}
