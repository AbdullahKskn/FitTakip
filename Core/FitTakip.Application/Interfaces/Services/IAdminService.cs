using System;
using FitTakip.Application.Common;
using FitTakip.Application.Parametre;

namespace FitTakip.Application.Interfaces.Services;

public interface IAdminService
{
    Task<Result> AdminOlustur(AdminOlusturParametre parametre);
    Task<Result> AdminGuncelle(AdminGuncelleParametre parametre);
    Task<Result> AdminSil(int AdminId);
    Task<Result> AdminleriGetirPagination(int Baslangic, int Adet);
    Task<Result> IsletmeOlustur(IsletmeOlusturParametre parametre);
    Task<Result> IsletmeGuncelle(IsletmeGuncelleParametre parametre);
    Task<Result> IsletmeSil(int IsletmeId);
    Task<Result> IsletmeyeKullanımSuresiEkle(IsletmeyeKullanımSuresiEkleParametre parametre);
    Task<Result> IsletmeleriGetirPagination(int Baslangic, int Adet);
}
