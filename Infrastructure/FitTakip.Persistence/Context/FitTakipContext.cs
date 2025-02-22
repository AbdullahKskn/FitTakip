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

    public DbSet<Admin> Adminler { get; set; } = null!;
    public DbSet<Isletme> Isletmeler { get; set; } = null!;
    public DbSet<Egitmen> Egitmenler { get; set; } = null!;
    public DbSet<Uye> Uyeler { get; set; } = null!;
    public DbSet<Randevu> Randevular { get; set; } = null!;
    public DbSet<Olcum> Olcumler { get; set; } = null!;
    public DbSet<Gelir> Gelirler { get; set; } = null!;
    public DbSet<Gider> Giderler { get; set; } = null!;
    public DbSet<Paket> Paketler { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        // Isletme - Egitmen (One-to-Many)
        modelBuilder.Entity<Egitmen>()
            .HasOne(e => e.Isletme)
            .WithMany(i => i.Egitmenler)
            .HasForeignKey(e => e.IsletmeId)
            .OnDelete(DeleteBehavior.NoAction);

        // Isletme - Uye (One-to-Many)
        modelBuilder.Entity<Uye>()
            .HasOne(u => u.Isletme)
            .WithMany(i => i.Uyeler)
            .HasForeignKey(u => u.IsletmeId)
            .OnDelete(DeleteBehavior.NoAction);

        // Egitmen - Uye (One-to-Many)
        modelBuilder.Entity<Uye>()
            .HasOne(u => u.Egitmen)
            .WithMany(e => e.Uyeler)
            .HasForeignKey(u => u.EgitmenId)
            .OnDelete(DeleteBehavior.NoAction); // Eğitmen silinirse üye boşa düşmesin

        // Uye - Olcum (One-to-Many)
        modelBuilder.Entity<Olcum>()
            .HasOne(o => o.Uye)
            .WithMany(u => u.Olcumler)
            .HasForeignKey(o => o.UyeId)
            .OnDelete(DeleteBehavior.NoAction);

        // Uye - Randevu (One-to-Many)
        modelBuilder.Entity<Randevu>()
            .HasOne(r => r.Uye)
            .WithMany(u => u.Randevular)
            .HasForeignKey(r => r.UyeId)
            .OnDelete(DeleteBehavior.NoAction);

        // Egitmen - Randevu (One-to-Many)
        modelBuilder.Entity<Randevu>()
            .HasOne(r => r.Egitmen)
            .WithMany(e => e.Randevular)
            .HasForeignKey(r => r.EgitmenId)
            .OnDelete(DeleteBehavior.NoAction);

        // Paket - Isletme ilişkisi (One-to-Many)
        modelBuilder.Entity<Paket>()
            .HasOne(p => p.Isletme)
            .WithMany(i => i.Paketler)
            .HasForeignKey(p => p.IsletmeId)
            .OnDelete(DeleteBehavior.NoAction);

        // Uye - Paket ilişkisi (One-to-Many)
        modelBuilder.Entity<Uye>()
            .HasOne(u => u.Paket)
            .WithMany(p => p.Uyeler)
            .HasForeignKey(u => u.PaketId)
            .OnDelete(DeleteBehavior.NoAction);

        // Kullanıcı Adlarını Unique Yapma
        modelBuilder.Entity<Admin>()
            .HasIndex(i => i.KullaniciAdi)
            .IsUnique();

        modelBuilder.Entity<Isletme>()
            .HasIndex(i => i.KullaniciAdi)
            .IsUnique();

        modelBuilder.Entity<Egitmen>()
            .HasIndex(e => e.KullaniciAdi)
            .IsUnique();

    }

}
