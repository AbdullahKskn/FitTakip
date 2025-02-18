using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IKullaniciRepository
{
    Task<bool> KullaniciAdiVarMiAsync(string KullaniciAdi);
    Task<List<Isletme>> IsletmeleriGetirPaginationAsync(int Baslangic, int Adet);
    Task<List<Admin?>> AdminleriGetirPaginationAsync(int Baslangic, int Adet);
    Task<List<Egitmen?>> TumEgitmenleriGetirAsync(int IsletmeId);
    Task<List<Uye>> TumUyeleriGetirAsync(int IsletmeId);
    Task<List<Egitmen?>> EgitmenleriGetirPaginationAsync(int IsletmeId, int Baslangic, int Adet);
    Task<List<Uye?>> UyeleriGetirPaginationAsync(int IsletmeId, int Baslangic, int Adet);
    Task<List<Uye>> PotansiyelMusterileriGetirPaginationAsync(int IsletmeId, int Baslangic, int Adet);
}
