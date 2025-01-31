using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class EgitmenOlusturParametreValidator : AbstractValidator<EgitmenOlusturParametre>
{
    public EgitmenOlusturParametreValidator()
    {
        RuleFor(r => r.Ad).NotNull().NotEmpty().WithMessage("Eğitmen Adı Boş Olamaz.");
        RuleFor(r => r.Soyad).NotNull().NotEmpty().WithMessage("Eğitmen Soyadı Boş Olamaz.");
        RuleFor(r => r.KullaniciAdi).NotNull().NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz.");
        RuleFor(r => r.Sifre).NotNull().NotEmpty().WithMessage("Şifre Boş Olamaz.");
        RuleFor(r => r.IsletmeId).NotNull().NotEmpty().WithMessage("İşletme ID Boş Olamaz.");
    }
}
