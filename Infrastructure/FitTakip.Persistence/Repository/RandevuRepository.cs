using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Domain.Entities;
using FitTakip.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitTakip.Persistence.Repository;

public class RandevuRepository : IRandevuRepository
{
    private readonly FitTakipContext _context;

    public RandevuRepository(FitTakipContext context)
    {
        _context = context;
    }

    public async Task<List<Randevu?>> UyeyeAitRandevulariGetirAsync(int UyeId, int Baslangic, int Adet)
    {
        return await _context.Randevular.Where(w => w.UyeId == UyeId).Include(i => i.Uye).Include(i => i.Egitmen).OrderByDescending(o => o.Tarih).Skip(Baslangic).Take(Adet).ToListAsync();
    }

    public async Task<List<Randevu?>> GunlukRandevuGetirAsync(int EgitmenId, DateTime Tarih)
    {
        var baslangicTarih = Tarih.Date;
        var bitisTarih = Tarih.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        return await _context.Randevular.Where(w => w.EgitmenId == EgitmenId && w.Tarih >= baslangicTarih && w.Tarih <= bitisTarih).Include(i => i.Uye).OrderBy(o => o.Tarih).ToListAsync();
    }
}
