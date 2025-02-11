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

    public async Task<Kullanici?> KullaniciAdınaGöreGetir(string KullaniciAdi)
    {
        return await _context.Kullanicilar.AsNoTracking().FirstOrDefaultAsync(f => f.KullaniciAdi == KullaniciAdi);
    }
}
