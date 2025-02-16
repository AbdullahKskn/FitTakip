using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IGiderRepository
{
    Task<decimal> TumGiderlerToplamiAsync(int IsletmeId);
    Task<List<Gider>> GiderleriTariheGöreGetirPaginationAsync(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet);
    Task<decimal> GiderleriTariheGöreToplaAsync(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi);
}
