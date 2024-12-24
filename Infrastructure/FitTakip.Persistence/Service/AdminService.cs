using System;
using FitTakip.Application.Common;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using FitTakip.Domain.Entities;
using FitTakip.Domain.Enum;

namespace FitTakip.Persistence.Service;

public class AdminService : IAdminService
{
    private readonly IRepository<Kullanici> _repository;
    private readonly AuthService _authService;
    private readonly IKullaniciRepository _kullaniciRepository;

    public AdminService(IRepository<Kullanici> repository, IKullaniciRepository kullaniciRepository, AuthService authService)
    {
        _repository = repository;
        _kullaniciRepository = kullaniciRepository;
        _authService = authService;
    }

    public async Task<Result> AdminOlustur(AdminOlusturParametre parametre)
    {
        try
        {
            var kullaniciAdiVarMi = await _kullaniciRepository.KullaniciAdiVarMiAsync(parametre.KullaniciAdi);

            if (kullaniciAdiVarMi != null)
                return new Result(false, "Sistemde Kullanıcı Kaydı Mevcuttur.");

            var sifreKarmasi = _authService.HashPassword(parametre.Sifre);

            var admin = new Kullanici
            {
                Ad = parametre.Ad,
                Soyad = parametre.Soyad,
                TelefonNo = parametre.TelefonNo,
                KullaniciAdi = parametre.KullaniciAdi,
                SifreKarmasi = sifreKarmasi,
                DogumTarihi = parametre.DogumTarihi,
                Statu = Statu.Admin,
                AktifMi = true,
            };

            await _repository.CreateAsync(admin);

            return new Result(true, "Admin Başarıyla Oluşturuldu.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }
}
