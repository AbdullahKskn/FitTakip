using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class AdminOlusturParametreValidator : AbstractValidator<AdminOlusturParametre>
{
    public AdminOlusturParametreValidator()
    {
        RuleFor(r => r.Ad).NotEmpty().WithMessage("Ad Bilgisi Boş Olamaz.");
        RuleFor(r => r.Soyad).NotEmpty().WithMessage("Soyad Bilgisi Boş Olamaz.");
        RuleFor(r => r.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz.");
        RuleFor(r => r.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz.");
    }
}
