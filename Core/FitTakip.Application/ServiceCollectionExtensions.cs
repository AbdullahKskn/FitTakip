using FitTakip.Application.FluentValidation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace FitTakip.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // Add FluentValidation
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        // Register validators
        services.AddValidatorsFromAssemblyContaining<GirisYapParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<AdminOlusturParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<AdminGuncelleParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<IsletmeOlusturParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<IsletmeGuncelleParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<EgitmenOlusturParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<EgitmenGuncelleParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<UyeOlusturParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<UyeGuncelleParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<RandevuOlusturParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<OlcumOlusturParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<GelirOlusturParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<IsletmeyeKullanımSuresiEkleParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<GiderOlusturParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<PaketEkleParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<UyeyePaketEkleParametreValidator>();
    }
}