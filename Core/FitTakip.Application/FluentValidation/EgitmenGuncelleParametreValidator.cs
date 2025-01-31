using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class EgitmenGuncelleParametreValidator : AbstractValidator<EgitmenGuncelleParametre>
{
    public EgitmenGuncelleParametreValidator()
    {
        RuleFor(r => r.EgitmenId).NotNull().NotEmpty().WithMessage("Eğitmen ID Boş Olamaz.");
    }
}
