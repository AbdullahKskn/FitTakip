using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IOlcumRepository
{
    Task<List<Olcum?>> UyeyeAitOlcumleriGetirAsync(long UyeId, int Baslangic, int Adet);
}
