using System;
using FitTakip.Application.Common;
using FitTakip.Application.Parametre;

namespace FitTakip.Application.Interfaces.Services;

public interface IEgitmenService
{
    Task<Result> UyeOlustur(UyeOlusturParametre parametre);
    Task<Result> UyeGuncelle(UyeGuncelleParametre parametre);
    Task<Result> UyeSil(long UyeId);
    Task<Result> UyeleriGetirPagination(long EgitmenId, int Baslangic, int Adet);
    Task<Result> TumUyeleriGetir(long EgitmenId);
    Task<Result> UyeyePaketEkle(UyeyePaketEkleParametre parametre);
    Task<Result> RandevuOlustur(RandevuOlusturParametre parametre);
    Task<Result> UyeyeAitRandevularıGetirPagination(long UyeId, int Baslangic, int Adet);
    Task<Result> GunlukRandevuGetir(long EgitmenId, DateTime Tarih);
    Task<Result> OlcumOlustur(OlcumOlusturParametre parametre);
    Task<Result> UyeOlcumGetirPagination(long UyeId, int Baslangic, int Adet);
    Task<Result> PaketleriGetir(long IsletmeId);
    Task<Result> SifreDegistir(SifreDegistirParametre parametre);
}
