using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IRandevuRepository
{
    Task<List<Randevu?>> UyeyeAitRandevulariGetirAsync(int UyeId, int Baslangic, int Adet);
    Task<List<Randevu?>> GunlukRandevuGetirAsync(int EgitmenId, DateTime Tarih);
}
