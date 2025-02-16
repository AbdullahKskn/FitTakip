using System;
using FitTakip.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FitTakip.Persistence.Context;

public class FitTakipContext : DbContext
{
    public FitTakipContext(DbContextOptions<FitTakipContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=104.247.167.130\\MSSQLSERVER2019;Database=ptrainer_FitPlanDemo;User Id=ptrainer_demoAdmin;Password=Cr57kl43?;Integrated Security=False;TrustServerCertificate=True;");
    }

    public DbSet<Kullanici> Kullanicilar { get; set; } = null!;
    public DbSet<Randevu> Randevular { get; set; } = null!;
    public DbSet<Olcum> Olcumler { get; set; } = null!;
    public DbSet<Gelir> Gelirler { get; set; } = null!;
    public DbSet<Gider> Giderler { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kullanici>()
            .HasOne(r => r.Egitmen)
            .WithMany(e => e.Uyeler)
            .HasForeignKey(k => k.EgitmenId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Randevu>()
            .HasOne(r => r.Uye)
            .WithMany(k => k.UyeRandevulari)
            .HasForeignKey(r => r.UyeId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Randevu>()
            .HasOne(r => r.Egitmen)
            .WithMany(k => k.EgitmenRandevulari)
            .HasForeignKey(r => r.EgitmenId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Olcum>()
            .Property(o => o.Kilo)
            .HasPrecision(5, 2); // Kilo için hassasiyet ayarı

        base.OnModelCreating(modelBuilder);
    }

}
