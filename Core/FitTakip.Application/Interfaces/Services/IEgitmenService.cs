using System;
using FitTakip.Application.Common;
using FitTakip.Application.Parametre;

namespace FitTakip.Application.Interfaces.Services;

public interface IEgitmenService
{
    Task<Result> UyeOlustur(UyeOlusturParametre parametre);
    Task<Result> UyeGuncelle(UyeGuncelleParametre parametre);
    Task<Result> UyeSil(int UyeId);
    Task<Result> UyeyePaketEkle(UyeyePaketEkleParametre parametre);
    Task<Result> RandevuOlustur(RandevuOlusturParametre parametre);
    Task<Result> UyeyeAitRandevularıGetirPagination(int UyeId, int Baslangic, int Adet);
    Task<Result> GunlukRandevuGetir(int EgitmenId, DateTime Tarih);
    Task<Result> OlcumOlustur(OlcumOlusturParametre parametre);
    Task<Result> UyeOlcumGetirPagination(int UyeId, int Baslangic, int Adet);
    Task<Result> PaketleriGetir(int IsletmeId);
}
