using System;
using FitTakip.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FitTakip.Persistence
{
    public class FitTakipContextFactory : IDesignTimeDbContextFactory<FitTakipContext>
    {
        public FitTakipContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<FitTakipContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new FitTakipContext(optionsBuilder.Options, configuration);
        }
    }
}