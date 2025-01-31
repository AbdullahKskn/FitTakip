using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class AdminOlusturParametreValidator : AbstractValidator<AdminOlusturParametre>
{
    public AdminOlusturParametreValidator()
    {
        RuleFor(r => r.Ad).NotNull().NotEmpty().WithMessage("Ad Bilgisi Boş Olamaz.");
        RuleFor(r => r.Soyad).NotNull().NotEmpty().WithMessage("Soyad Bilgisi Boş Olamaz.");
        RuleFor(r => r.KullaniciAdi).NotNull().NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz.");
        RuleFor(r => r.Sifre).NotNull().NotEmpty().WithMessage("Şifre Boş Olamaz.");
    }
}
