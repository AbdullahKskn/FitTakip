using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IKullaniciRepository
{
    Task<Kullanici?> KullaniciAdiVarMiAsync(string KullaniciAdi);
    Task<List<Kullanici?>> IsletmeleriGetirPaginationAsync(int Baslangic, int Adet);
    Task<List<Kullanici?>> AdminleriGetirPaginationAsync(int Baslangic, int Adet);
    Task<List<Kullanici?>> TumEgitmenleriGetirAsync(int IsletmeId);
    Task<List<Kullanici?>> EgitmenleriGetirPaginationAsync(int IsletmeId, int Baslangic, int Adet);
    Task<List<Kullanici?>> UyeleriGetirPaginationAsync(int IsletmeId, int Baslangic, int Adet);
}
