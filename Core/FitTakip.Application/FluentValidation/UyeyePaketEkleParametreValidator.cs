using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class UyeyePaketEkleParametreValidator : AbstractValidator<UyeyePaketEkleParametre>
{
    public UyeyePaketEkleParametreValidator()
    {
        RuleFor(r => r.UyeId).NotEmpty().NotNull().WithMessage("Üye Id Boş Olamaz");
        RuleFor(r => r.PaketId).NotEmpty().NotNull().WithMessage("Paket Id Boş Olamaz");
    }
}
