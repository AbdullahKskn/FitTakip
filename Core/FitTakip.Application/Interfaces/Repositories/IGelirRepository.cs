using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Services;

public interface IGelirRepository
{
    Task<decimal> TumGelirlerToplamiAsync(int IsletmeId);
    Task<List<Gelir>> GelirleriTariheGöreGetirPaginationAsync(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet);
    Task<decimal> GelirleriTariheGöreToplaAsync(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi);
}
