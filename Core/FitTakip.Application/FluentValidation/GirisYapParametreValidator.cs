using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class GirisYapParametreValidator : AbstractValidator<GirisYapParametre>
{
    public GirisYapParametreValidator()
    {
        RuleFor(r => r.KullaniciAdi).NotNull().NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
        RuleFor(r => r.Sifre).NotNull().NotEmpty().WithMessage("Şifre Boş Olamaz");
    }
}
