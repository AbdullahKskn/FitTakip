using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class IsletmeOlusturParametreValidator : AbstractValidator<IsletmeOlusturParametre>
{
    public IsletmeOlusturParametreValidator()
    {
        RuleFor(r => r.Ad).NotNull().NotEmpty().WithMessage("İşletme Adı Boş Olamaz.");
        RuleFor(r => r.TelefonNo).NotNull().NotEmpty().WithMessage("İşletmeye Ait İletişim Bilgisi Boş Olamaz.");
        RuleFor(r => r.KullaniciAdi).NotNull().NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz.");
        RuleFor(r => r.Sifre).NotNull().NotEmpty().WithMessage("Şifre Boş Olamaz.");
        RuleFor(r => r.AbonelikYilEkle).NotNull().NotEmpty().WithMessage("Abonelik Sonlanma Tarihi Boş Olamaz.");
    }
}
