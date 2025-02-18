using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class UyeOlusturParametreValidator : AbstractValidator<UyeOlusturParametre>
{
    public UyeOlusturParametreValidator()
    {
        RuleFor(r => r.Ad).NotNull().NotEmpty().WithMessage("Ad Bilgisi Boş Olamaz.");
        RuleFor(r => r.Soyad).NotNull().NotEmpty().WithMessage("Soyad Bilgisi Boş Olamaz.");
        RuleFor(r => r.DersSayisi).NotNull().NotEmpty().WithMessage("Ders Sayısı Boş Olamaz.");
        RuleFor(r => r.IsletmeId).NotNull().NotEmpty().WithMessage("İşletme Id Boş Olamaz.");
        RuleFor(r => r.EgitmenId).NotNull().NotEmpty().WithMessage("Eğitmen Id Boş Olamaz.");
    }
}
