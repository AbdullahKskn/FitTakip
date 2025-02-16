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
            var optionsBuilder = new DbContextOptionsBuilder<FitTakipContext>();
            optionsBuilder.UseSqlServer("Server=104.247.167.130\\MSSQLSERVER2019;Database=ptrainer_FitPlanDemo;User Id=ptrainer_demoAdmin;Password=Cr57kl43?;Integrated Security=False;TrustServerCertificate=True;");

            return new FitTakipContext(optionsBuilder.Options);
        }
    }
}