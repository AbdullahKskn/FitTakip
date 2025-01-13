using System;
using FitTakip.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FitTakip.Persistence;

public class FitTakipContextFactory : IDesignTimeDbContextFactory<FitTakipContext>
{
    public FitTakipContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FitTakipContext>();
        optionsBuilder.UseSqlServer("Server=104.247.167.130\\MSSQLSERVER2019;Database=ptrainer_FitPlanDb;User Id=ptrainer_admin;Password=Ti587fd6*;Integrated Security=False;TrustServerCertificate=True;");

        return new FitTakipContext(optionsBuilder.Options);
    }
}
