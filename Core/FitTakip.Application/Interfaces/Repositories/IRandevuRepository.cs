using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IRandevuRepository
{
    Task<List<Randevu?>> UyeyeAitRandevulariGetirAsync(long UyeId, int Baslangic, int Adet);
    Task<List<Randevu?>> GunlukRandevuGetirAsync(long EgitmenId, DateTime Tarih);
    Task<List<Randevu?>> UyeyeAitRandevulariTariheGoreGetirAsync(long UyeId, DateTime BaslangicTarih, DateTime BitisTarih, int Adet, int Baslangic);
    Task<DateTime?> SonRandevuGetirAsync(long UyeId);
    Task<int> EgitmenTariheGöreDersSayisiGetirAsync(long EgitmenId, DateTime BaslangicTarih, DateTime BitisTarih);
    Task<List<Randevu>> EgitmenTariheGöreTumRandeculariGetirAsync(long EgitmenId, DateTime BaslangicTarih, DateTime BitisTarih);
}
