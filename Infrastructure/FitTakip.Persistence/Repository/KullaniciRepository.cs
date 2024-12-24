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

    public async Task<Kullanici?> KullaniciAdiVarMiAsync(string KullaniciAdi)
    {
        return await _context.Kullanicilar.FirstOrDefaultAsync(k => k.KullaniciAdi == KullaniciAdi);
    }

}
