using System;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Domain.Entities;
using FitTakip.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitTakip.Persistence.Repository;

public class PaketRepository : IPaketRepository
{
    private readonly FitTakipContext _context;

    public PaketRepository(FitTakipContext context)
    {
        _context = context;
    }

    public async Task<List<Paket>> IsletmeyeAitPaketleriGetirAsync(long IsletmeId)
    {
        return await _context.Paketler.AsNoTracking().Where(w => w.IsletmeId == IsletmeId && w.AktifMi == true).OrderBy(o => o.PaketId).ToListAsync();
    }
}
