using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IGiderRepository
{
    Task<decimal> TumGiderlerToplamiAsync(long IsletmeId);
    Task<List<Gider>> GiderleriTariheGöreGetirPaginationAsync(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet);
    Task<decimal> GiderleriTariheGöreToplaAsync(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi);
}
