using System;
using FitTakip.Application.Interfaces.Services;
using FitTakip.Domain.Entities;
using FitTakip.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitTakip.Persistence.Repository;

public class GelirRepository : IGelirRepository
{
    private readonly FitTakipContext _context;

    public GelirRepository(FitTakipContext context)
    {
        _context = context;
    }

    public async Task<decimal> TumGelirlerToplamiAsync(int IsletmeId)
    {
        return await _context.Gelirler.Where(w => w.IsletmeId == IsletmeId).SumAsync(s => s.Tutar);
    }

    public async Task<List<Gelir>> GelirleriTariheGöreGetirPaginationAsync(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet)
    {
        var baslangicTarihi = BaslangicTarihi.Date;
        var bitisTarihi = BitisTarihi.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        return await _context.Gelirler.Where(w => w.IsletmeId == IsletmeId && w.Tarih >= baslangicTarihi && w.Tarih <= bitisTarihi).OrderByDescending(o => o.Tarih).Skip(Baslangic).Take(Adet).ToListAsync();
    }

    public async Task<decimal> GelirleriTariheGöreToplaAsync(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi)
    {
        var baslangicTarihi = BaslangicTarihi.Date;
        var bitisTarihi = BitisTarihi.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        return await _context.Gelirler.Where(w => w.IsletmeId == IsletmeId && w.Tarih >= baslangicTarihi && w.Tarih <= bitisTarihi).SumAsync(s => s.Tutar);
    }
}
