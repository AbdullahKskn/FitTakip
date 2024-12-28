using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class IsletmeGuncelleParametreValidator : AbstractValidator<IsletmeGuncelleParametre>
{
    public IsletmeGuncelleParametreValidator()
    {
        RuleFor(r => r.IsletmeId).NotEmpty().WithMessage("İşletme ID Boş Olamaz.");
    }
}
