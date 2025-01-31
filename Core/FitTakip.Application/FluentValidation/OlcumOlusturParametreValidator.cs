using System;
using FitTakip.Application.Parametre;
using FluentValidation;

namespace FitTakip.Application.FluentValidation;

public class OlcumOlusturParametreValidator : AbstractValidator<OlcumOlusturParametre>
{
    public OlcumOlusturParametreValidator()
    {
        RuleFor(r => r.UyeId).NotNull().NotEmpty().WithMessage("Üye Id Boş Olamaz.");
        RuleFor(r => r.Tarih).NotNull().NotEmpty().WithMessage("Tarih Bilgisi Boş Olamaz.");
        RuleFor(r => r.Boy).NotNull().NotEmpty().WithMessage("Boy Bilgisi Boş Olamaz.");
        RuleFor(r => r.Kilo).NotNull().NotEmpty().WithMessage("Kilo Bilgisi Boş Olamaz.");
        RuleFor(r => r.Omuz).NotNull().NotEmpty().WithMessage("Omuz Ölçüsü Boş Olamaz.");
        RuleFor(r => r.Gogus).NotNull().NotEmpty().WithMessage("Göğüs Ölçüsü Boş Olamaz.");
        RuleFor(r => r.SagKol).NotNull().NotEmpty().WithMessage("Sağ Kol Ölçüsü Boş Olamaz.");
        RuleFor(r => r.SolKol).NotNull().NotEmpty().WithMessage("Sol Kol Ölçüsü Boş Olamaz.");
        RuleFor(r => r.Bel).NotNull().NotEmpty().WithMessage("Bel Ölçüsü Boş Olamaz.");
        RuleFor(r => r.Kalca).NotNull().NotEmpty().WithMessage("Kalça Ölçüsü Boş Olamaz.");
        RuleFor(r => r.SagBacak).NotNull().NotEmpty().WithMessage("Sağ Bacak Ölçüsü Boş Olamaz.");
        RuleFor(r => r.SolBacak).NotNull().NotEmpty().WithMessage("Sol Bacak Ölçüsü Boş Olamaz.");
    }
}
