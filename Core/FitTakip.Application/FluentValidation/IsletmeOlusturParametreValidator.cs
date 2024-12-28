using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class IsletmeOlusturParametreValidator : AbstractValidator<IsletmeOlusturParametre>
{
    public IsletmeOlusturParametreValidator()
    {
        RuleFor(r => r.Ad).NotEmpty().WithMessage("İşletme Adı Boş Olamaz.");
        RuleFor(r => r.TelefonNo).NotEmpty().WithMessage("İşletmeye Ait İletişim Bilgisi Boş Olamaz.");
        RuleFor(r => r.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz.");
        RuleFor(r => r.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz.");
        RuleFor(r => r.AbonelikSonlanmaTarihi).NotEmpty().WithMessage("Abonelik Sonlanma Tarihi Boş Olamaz.");
    }
}
