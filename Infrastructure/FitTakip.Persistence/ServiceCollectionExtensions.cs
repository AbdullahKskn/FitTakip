using System;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Application.Interfaces.Services;
using FitTakip.Persistence.Context;
using FitTakip.Persistence.Repository;
using FitTakip.Persistence.Service;
using Microsoft.Extensions.DependencyInjection;

namespace FitTakip.Persistence;

public static class ServiceCollectionExtensions
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        // Configure the database context
        services.AddDbContext<FitTakipContext>();

        // Register repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<AuthService, AuthService>();
        services.AddScoped<IKullaniciRepository, KullaniciRepository>();
        services.AddScoped<ILoginRepository, LoginRepository>();

        // Register Services
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<ILoginService, LoginService>();
    }
}
