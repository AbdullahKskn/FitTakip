using System;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Domain.Entities;
using FitTakip.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitTakip.Persistence.Repository;

public class LoginRepository : ILoginRepository
{
    private readonly FitTakipContext _context;

    public LoginRepository(FitTakipContext context)
    {
        _context = context;
    }

    public async Task<Admin> AdminKullaniciAdınaGöreGetir(string KullaniciAdi)
    {
        return await _context.Adminler.AsNoTracking().FirstOrDefaultAsync(f => f.KullaniciAdi == KullaniciAdi);
    }
    public async Task<Isletme> IsletmeKullaniciAdınaGöreGetir(string KullaniciAdi)
    {
        return await _context.Isletmeler.AsNoTracking().FirstOrDefaultAsync(f => f.KullaniciAdi == KullaniciAdi);
    }
    public async Task<Egitmen> EgitmenKullaniciAdınaGöreGetir(string KullaniciAdi)
    {
        return await _context.Egitmenler.AsNoTracking().Include(i => i.Isletme).FirstOrDefaultAsync(f => f.KullaniciAdi == KullaniciAdi);
    }
}
