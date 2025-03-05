using System;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Domain.Entities;
using FitTakip.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitTakip.Persistence.Repository;

public class KullaniciRepository : IKullaniciRepository
{
    private readonly FitTakipContext _context;

    public KullaniciRepository(FitTakipContext context)
    {
        _context = context;
    }

    public async Task<bool> KullaniciAdiVarMiAsync(string KullaniciAdi)
    {
        var admin = await _context.Adminler.AsNoTracking().AnyAsync(k => k.KullaniciAdi == KullaniciAdi);
        var isletme = await _context.Isletmeler.AsNoTracking().AnyAsync(k => k.KullaniciAdi == KullaniciAdi);
        var egitmen = await _context.Egitmenler.AsNoTracking().AnyAsync(k => k.KullaniciAdi == KullaniciAdi);

        return admin || isletme || egitmen;
    }

    public async Task<List<Admin>> AdminleriGetirPaginationAsync(int Baslangic, int Adet)
    {
        return await _context.Adminler.AsNoTracking().Where(w => w.AktifMi == true).OrderBy(o => o.Ad).Skip(Baslangic).Take(Adet).ToListAsync();
    }
    public async Task<List<Isletme>> IsletmeleriGetirPaginationAsync(int Baslangic, int Adet)
    {
        return await _context.Isletmeler.AsNoTracking().Where(w => w.AktifMi == true).OrderBy(o => o.Ad).Skip(Baslangic).Take(Adet).ToListAsync();
    }

    public async Task<List<Egitmen>> TumEgitmenleriGetirAsync(long IsletmeId)
    {
        return await _context.Egitmenler.AsNoTracking().Where(w => w.IsletmeId == IsletmeId && w.AktifMi == true).OrderBy(o => o.Ad).ToListAsync();
    }

    public async Task<List<Uye>> TumUyeleriGetirAsync(long IsletmeId)
    {
        return await _context.Uyeler.AsNoTracking().Where(w => w.IsletmeId == IsletmeId && w.AktifMi == true).OrderBy(o => o.Ad).ToListAsync();
    }

    public async Task<List<Egitmen>> EgitmenleriGetirPaginationAsync(long IsletmeId, int Baslangic, int Adet)
    {
        return await _context.Egitmenler.AsNoTracking().Where(w => w.IsletmeId == IsletmeId && w.AktifMi == true).OrderBy(o => o.Ad).Skip(Baslangic).Take(Adet).ToListAsync();
    }

    public async Task<List<Uye>> UyeleriGetirPaginationAsync(long IsletmeId, int Baslangic, int Adet)
    {
        return await _context.Uyeler.AsNoTracking().Where(w => w.IsletmeId == IsletmeId && w.AktifMi == true).OrderBy(o => o.Ad).Include(i => i.Egitmen).Skip(Baslangic).Take(Adet).ToListAsync();
    }

    public async Task<List<Uye>> PotansiyelMusterileriGetirPaginationAsync(long IsletmeId, int Baslangic, int Adet)
    {
        return await _context.Uyeler.AsNoTracking().Where(w => w.IsletmeId == IsletmeId && w.KalanDersSayisi <= 0).OrderBy(o => o.Ad).Skip(Baslangic).Take(Adet).ToListAsync();
    }
}
