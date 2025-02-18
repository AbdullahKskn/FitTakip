using System;
using FitTakip.Domain.Entities;

namespace FitTakip.Application.Interfaces.Repositories;

public interface ILoginRepository
{
    Task<Admin> AdminKullaniciAdınaGöreGetir(string KullaniciAdi);
    Task<Isletme> IsletmeKullaniciAdınaGöreGetir(string KullaniciAdi);
    Task<Egitmen> EgitmenKullaniciAdınaGöreGetir(string KullaniciAdi);
}
