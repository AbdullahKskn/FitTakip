using System;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Domain.Entities;
using FitTakip.Domain.Enum;
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

    public async Task<Kullanici?> KullaniciAdiVarMiAsync(string KullaniciAdi)
    {
        return await _context.Kullanicilar.FirstOrDefaultAsync(k => k.KullaniciAdi == KullaniciAdi);
    }

    public async Task<List<Kullanici?>> IsletmeleriGetirPaginationAsync(int Baslangic, int Adet)
    {
        return await _context.Kullanicilar.Where(w => w.Statu == Statu.Isletme).Skip(Baslangic).Take(Adet).ToListAsync();
    }

    public async Task<List<Kullanici?>> AdminleriGetirPaginationAsync(int Baslangic, int Adet)
    {
        return await _context.Kullanicilar.Where(w => w.Statu == Statu.Admin && w.AktifMi == true).Skip(Baslangic).Take(Adet).ToListAsync();
    }

    public async Task<List<Kullanici?>> TumEgitmenleriGetirAsync(int IsletmeId)
    {
        return await _context.Kullanicilar.Where(w => w.IsletmeId == IsletmeId && w.Statu == Statu.Egitmen && w.AktifMi == true).ToListAsync();
    }

    public async Task<List<Kullanici?>> EgitmenleriGetirPaginationAsync(int IsletmeId, int Baslangic, int Adet)
    {
        return await _context.Kullanicilar.Where(w => w.IsletmeId == IsletmeId && w.Statu == Statu.Egitmen && w.AktifMi == true).Skip(Baslangic).Take(Adet).ToListAsync();
    }

    public async Task<List<Kullanici?>> UyeleriGetirPaginationAsync(int IsletmeId, int Baslangic, int Adet)
    {
        return await _context.Kullanicilar.Where(w => w.Statu == Statu.Uye && w.IsletmeId == IsletmeId && w.AktifMi == true).Include(i => i.Egitmen).Skip(Baslangic).Take(Adet).ToListAsync();
    }

}
