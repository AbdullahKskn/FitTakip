using System;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Domain.Entities;
using FitTakip.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitTakip.Persistence.Repository;

public class OlcumRepository : IOlcumRepository
{
    private readonly FitTakipContext _context;

    public OlcumRepository(FitTakipContext context)
    {
        _context = context;
    }

    public async Task<List<Olcum?>> UyeyeAitOlcumleriGetirAsync(int UyeId, int Baslangic, int Adet)
    {
        return await _context.Olcumler.Where(w => w.UyeId == UyeId).Include(i => i.Uye).OrderByDescending(o => o.Tarih).Skip(Baslangic).Take(Adet).ToListAsync();
    }
}
