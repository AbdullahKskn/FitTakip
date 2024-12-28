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
        services.AddValidatorsFromAssemblyContaining<AdminOlusturParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<AdminGuncelleParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<IsletmeOlusturParametreValidator>();
        services.AddValidatorsFromAssemblyContaining<IsletmeGuncelleParametreValidator>();

    }
}
