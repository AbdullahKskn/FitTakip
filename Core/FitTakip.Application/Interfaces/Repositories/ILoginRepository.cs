using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface ILoginRepository
{
    Task<Kullanici?> KullaniciAdınaGöreGetir(string KullaniciAdi);
}
