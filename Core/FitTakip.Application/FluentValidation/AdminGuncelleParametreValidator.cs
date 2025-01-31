using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class AdminGuncelleParametreValidator : AbstractValidator<AdminGuncelleParametre>
{
    public AdminGuncelleParametreValidator()
    {
        RuleFor(r => r.AdminId).NotNull().NotEmpty().WithMessage("Admin ID Boş Olamaz.");
    }
}
