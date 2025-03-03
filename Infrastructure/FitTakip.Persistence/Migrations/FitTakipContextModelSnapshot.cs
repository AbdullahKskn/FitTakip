﻿// <auto-generated />
using System;
using FitTakip.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitTakip.Persistence.Migrations
{
    [DbContext(typeof(FitTakipContext))]
    partial class FitTakipContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitTakip.Domain.Entities.Admin", b =>
                {
                    b.Property<long>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AdminId"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SifreKarmasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.HasIndex("KullaniciAdi")
                        .IsUnique();

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Egitmen", b =>
                {
                    b.Property<long>("EgitmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EgitmenId"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<long>("IsletmeId")
                        .HasColumnType("bigint");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SifreKarmasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EgitmenId");

                    b.HasIndex("IsletmeId");

                    b.HasIndex("KullaniciAdi")
                        .IsUnique();

                    b.ToTable("Egitmenler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Gelir", b =>
                {
                    b.Property<long>("GelirId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GelirId"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IsletmeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GelirId");

                    b.ToTable("Gelirler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Gider", b =>
                {
                    b.Property<long>("GiderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GiderId"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IsletmeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GiderId");

                    b.ToTable("Giderler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Isletme", b =>
                {
                    b.Property<long>("IsletmeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IsletmeId"));

                    b.Property<DateTime>("AbonelikSonlanmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SifreKarmasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IsletmeId");

                    b.HasIndex("KullaniciAdi")
                        .IsUnique();

                    b.ToTable("Isletmeler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Olcum", b =>
                {
                    b.Property<long>("OlcumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OlcumId"));

                    b.Property<int>("Bel")
                        .HasColumnType("int");

                    b.Property<int>("Boy")
                        .HasColumnType("int");

                    b.Property<int>("Gogus")
                        .HasColumnType("int");

                    b.Property<int>("Kalca")
                        .HasColumnType("int");

                    b.Property<decimal>("Kilo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Omuz")
                        .HasColumnType("int");

                    b.Property<int>("SagBacak")
                        .HasColumnType("int");

                    b.Property<int>("SagKol")
                        .HasColumnType("int");

                    b.Property<int>("SolBacak")
                        .HasColumnType("int");

                    b.Property<int>("SolKol")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<long>("UyeId")
                        .HasColumnType("bigint");

                    b.HasKey("OlcumId");

                    b.HasIndex("UyeId");

                    b.ToTable("Olcumler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Paket", b =>
                {
                    b.Property<long>("PaketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PaketId"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<int>("DersSayisi")
                        .HasColumnType("int");

                    b.Property<long>("IsletmeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PaketId");

                    b.HasIndex("IsletmeId");

                    b.ToTable("Paketler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Randevu", b =>
                {
                    b.Property<long>("RandevuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RandevuId"));

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EgitmenId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<long>("UyeId")
                        .HasColumnType("bigint");

                    b.HasKey("RandevuId");

                    b.HasIndex("EgitmenId");

                    b.HasIndex("UyeId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Uye", b =>
                {
                    b.Property<long>("UyeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UyeId"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<long>("EgitmenId")
                        .HasColumnType("bigint");

                    b.Property<long>("IsletmeId")
                        .HasColumnType("bigint");

                    b.Property<int>("KalanDersSayisi")
                        .HasColumnType("int");

                    b.Property<long>("PaketId")
                        .HasColumnType("bigint");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UyeId");

                    b.HasIndex("EgitmenId");

                    b.HasIndex("IsletmeId");

                    b.HasIndex("PaketId");

                    b.ToTable("Uyeler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Egitmen", b =>
                {
                    b.HasOne("FitTakip.Domain.Entities.Isletme", "Isletme")
                        .WithMany("Egitmenler")
                        .HasForeignKey("IsletmeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Isletme");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Olcum", b =>
                {
                    b.HasOne("FitTakip.Domain.Entities.Uye", "Uye")
                        .WithMany("Olcumler")
                        .HasForeignKey("UyeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Uye");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Paket", b =>
                {
                    b.HasOne("FitTakip.Domain.Entities.Isletme", "Isletme")
                        .WithMany("Paketler")
                        .HasForeignKey("IsletmeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Isletme");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Randevu", b =>
                {
                    b.HasOne("FitTakip.Domain.Entities.Egitmen", "Egitmen")
                        .WithMany("Randevular")
                        .HasForeignKey("EgitmenId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FitTakip.Domain.Entities.Uye", "Uye")
                        .WithMany("Randevular")
                        .HasForeignKey("UyeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Egitmen");

                    b.Navigation("Uye");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Uye", b =>
                {
                    b.HasOne("FitTakip.Domain.Entities.Egitmen", "Egitmen")
                        .WithMany("Uyeler")
                        .HasForeignKey("EgitmenId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FitTakip.Domain.Entities.Isletme", "Isletme")
                        .WithMany("Uyeler")
                        .HasForeignKey("IsletmeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FitTakip.Domain.Entities.Paket", "Paket")
                        .WithMany("Uyeler")
                        .HasForeignKey("PaketId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Egitmen");

                    b.Navigation("Isletme");

                    b.Navigation("Paket");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Egitmen", b =>
                {
                    b.Navigation("Randevular");

                    b.Navigation("Uyeler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Isletme", b =>
                {
                    b.Navigation("Egitmenler");

                    b.Navigation("Paketler");

                    b.Navigation("Uyeler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Paket", b =>
                {
                    b.Navigation("Uyeler");
                });

            modelBuilder.Entity("FitTakip.Domain.Entities.Uye", b =>
                {
                    b.Navigation("Olcumler");

                    b.Navigation("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}
