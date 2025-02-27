using System;
using FitTakip.Application.Common;
using FitTakip.Application.Parametre;

namespace FitTakip.Application.Interfaces.Services;

public interface IIsletmeService
{
    Task<Result> EgitmenOlustur(EgitmenOlusturParametre parametre);
    Task<Result> EgitmenGuncelle(EgitmenGuncelleParametre parametre);
    Task<Result> EgitmenSil(long EgitmenId);
    Task<Result> TumEgitmenleriGetir(long IsletmeId);
    Task<Result> TumUyeleriGetir(long IsletmeId);
    Task<Result> EgitmenleriGetirPagination(long IsletmeId, int Baslangic, int Adet);
    Task<Result> UyeleriGetirPagination(long IsletmeId, int Baslangic, int Adet);
    Task<Result> GelirOlustur(GelirOlusturParametre parametre);
    Task<Result> TumGelirlerToplami(long IsletmeId);
    Task<Result> GelirleriTariheGöreGetirPagination(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet);
    Task<Result> GelirleriTariheGöreTopla(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi);
    Task<Result> GiderOlustur(GiderOlusturParametre parametre);
    Task<Result> TumGiderlerToplami(long IsletmeId);
    Task<Result> GiderleriTariheGöreGetirPagination(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet);
    Task<Result> GiderleriTariheGöreTopla(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi);
    Task<Result> TumGelirGiderToplami(long IsletmeId);
    Task<Result> PotansiyelMusterileriGetirPagination(long IsletmeId, int Baslangic, int Adet);
    Task<Result> PaketEkle(PaketEkleParametre parametre);
    Task<Result> PaketSil(long PaketId);
    Task<Result> PaketleriGetir(long IsletmeId);
    Task<Result> EgitmenTariheGöreDersSayisiGetir(long EgitmenId, DateTime BaslangicTarih, DateTime BitisTarih);
    Task<Result> EgitmenMaasHesapla(long EgitmenId, DateTime BaslangicTarih, DateTime BitisTarih, int KomisyonOrani);
    Task<Result> SifreDegistir(SifreDegistirParametre parametre);
}
