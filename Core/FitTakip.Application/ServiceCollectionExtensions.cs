using System;
using FitTakip.Application.Parametre;
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
        services.AddValidatorsFromAssemblyContaining<AdminOlusturParametre>();

    }
}
