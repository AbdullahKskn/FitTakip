using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class IsletmeyeKullanımSuresiEkleParametreValidator : AbstractValidator<IsletmeyeKullanımSuresiEkleParametre>
{
    public IsletmeyeKullanımSuresiEkleParametreValidator()
    {
        RuleFor(r => r.IsletmeId).NotEmpty().NotNull().WithMessage("İşletme Id Boş Olamaz.");
        RuleFor(r => r.EklenecekYil).NotEmpty().NotNull().WithMessage("Eklenecek Yıl Sayısı Boş Olamaz.");
    }
}
