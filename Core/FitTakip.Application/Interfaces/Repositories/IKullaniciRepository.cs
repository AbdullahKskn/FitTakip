using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IKullaniciRepository
{
    Task<Kullanici?> KullaniciAdiVarMiAsync(string KullaniciAdi);
}
