using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Services;

public interface IGelirRepository
{
    Task<decimal> TumGelirlerToplamiAsync(long IsletmeId);
    Task<List<Gelir>> GelirleriTariheGöreGetirPaginationAsync(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet);
    Task<decimal> GelirleriTariheGöreToplaAsync(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi);
}
