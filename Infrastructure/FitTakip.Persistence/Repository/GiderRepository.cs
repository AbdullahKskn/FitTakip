using System;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Domain.Entities;
using FitTakip.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitTakip.Persistence.Repository;

public class GiderRepository : IGiderRepository
{
    private readonly FitTakipContext _context;

    public GiderRepository(FitTakipContext context)
    {
        _context = context;
    }

    public async Task<decimal> TumGiderlerToplamiAsync(int IsletmeId)
    {
        return await _context.Giderler.Where(w => w.IsletmeId == IsletmeId).SumAsync(s => s.Tutar);
    }

    public async Task<List<Gider>> GiderleriTariheGöreGetirPaginationAsync(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet)
    {
        var baslangicTarihi = BaslangicTarihi.Date;
        var bitisTarihi = BitisTarihi.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        return await _context.Giderler.Where(w => w.IsletmeId == IsletmeId && w.Tarih >= baslangicTarihi && w.Tarih <= bitisTarihi).OrderByDescending(o => o.Tarih).Skip(Baslangic).Take(Adet).ToListAsync();
    }

    public async Task<decimal> GiderleriTariheGöreToplaAsync(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi)
    {
        var baslangicTarihi = BaslangicTarihi.Date;
        var bitisTarihi = BitisTarihi.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        return await _context.Giderler.Where(w => w.IsletmeId == IsletmeId && w.Tarih >= baslangicTarihi && w.Tarih <= bitisTarihi).SumAsync(s => s.Tutar);
    }
}
