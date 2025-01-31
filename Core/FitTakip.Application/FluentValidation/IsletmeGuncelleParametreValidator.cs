using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class IsletmeGuncelleParametreValidator : AbstractValidator<IsletmeGuncelleParametre>
{
    public IsletmeGuncelleParametreValidator()
    {
        RuleFor(r => r.IsletmeId).NotNull().NotEmpty().WithMessage("İşletme ID Boş Olamaz.");
    }
}
