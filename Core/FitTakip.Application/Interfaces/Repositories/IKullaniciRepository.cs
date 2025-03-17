using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IKullaniciRepository
{
    Task<bool> KullaniciAdiVarMiAsync(string KullaniciAdi);
    Task<List<Isletme>> IsletmeleriGetirPaginationAsync(int Baslangic, int Adet);
    Task<List<Admin?>> AdminleriGetirPaginationAsync(int Baslangic, int Adet);
    Task<List<Egitmen?>> TumEgitmenleriGetirAsync(long IsletmeId);
    Task<List<Uye>> TumUyeleriGetirAsync(long IsletmeId);
    Task<List<Egitmen?>> EgitmenleriGetirPaginationAsync(long IsletmeId, int Baslangic, int Adet);
    Task<List<Uye?>> UyeleriGetirPaginationAsync(long IsletmeId, int Baslangic, int Adet);
    Task<List<Uye>> PotansiyelMusterileriGetirPaginationAsync(long IsletmeId, int Baslangic, int Adet);
    Task<List<Uye>> EgitmeneGöreUyeleriGetirPaginationAsync(long EgitmenId, int Baslangic, int Adet);
    Task<List<Uye>> EgitmeneGöreTumUyeleriGetirAsync(long EgitmenId);
    Task<List<Uye>> IsletmeUyeSorgulamaAsync(long IsletmeId, string? Ad, string? Soyad);
}
