using System;
using FitTakip.Application.Common;
using FitTakip.Application.Parametre;

namespace FitTakip.Application.Interfaces.Services;

public interface IIsletmeService
{
    Task<Result> EgitmenOlustur(EgitmenOlusturParametre parametre);
    Task<Result> EgitmenGuncelle(EgitmenGuncelleParametre parametre);
    Task<Result> EgitmenSil(int EgitmenId);
    Task<Result> TumEgitmenleriGetir(int IsletmeId);
    Task<Result> TumUyeleriGetir(int IsletmeId);
    Task<Result> EgitmenleriGetirPagination(int IsletmeId, int Baslangic, int Adet);
    Task<Result> UyeleriGetirPagination(int IsletmeId, int Baslangic, int Adet);
    Task<Result> GelirOlustur(GelirOlusturParametre parametre);
    Task<Result> TumGelirlerToplami(int IsletmeId);
    Task<Result> GelirleriTariheGöreGetirPagination(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet);
    Task<Result> GelirleriTariheGöreTopla(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi);
    Task<Result> GiderOlustur(GiderOlusturParametre parametre);
    Task<Result> TumGiderlerToplami(int IsletmeId);
    Task<Result> GiderleriTariheGöreGetirPagination(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet);
    Task<Result> GiderleriTariheGöreTopla(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi);
    Task<Result> TumGelirGiderToplami(int IsletmeId);
    Task<Result> PotansiyelMusterileriGetirPagination(int IsletmeId, int Baslangic, int Adet);
}
