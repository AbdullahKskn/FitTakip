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

    public async Task<Result> AdminGuncelle(AdminGuncelleParametre parametre)
    {
        try
        {
            var admin = await _repository.GetByIdAsync(parametre.AdminId);

            if (admin == null || admin.Statu != Statu.Admin)
                return new Result(false, "Sisteme Kayıtlı Admin Bulunamadı.");

            if (!string.IsNullOrWhiteSpace(parametre.Sifre))
            {
                var sifreKarmasi = _authService.HashPassword(parametre.Sifre);
                admin.SifreKarmasi = sifreKarmasi;
            }

            admin.Ad = parametre.Ad ?? admin.Ad;
            admin.Soyad = parametre.Soyad ?? admin.Soyad;
            admin.TelefonNo = parametre.TelefonNo ?? admin.TelefonNo;
            admin.KullaniciAdi = parametre.KullaniciAdi ?? admin.KullaniciAdi;
            admin.DogumTarihi = parametre.DogumTarihi ?? admin.DogumTarihi;

            await _repository.UpdateAsync(admin);

            return new Result(true, "Admin Başarıyla Güncellendi.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> AdminSil(int AdminId)
    {
        try
        {
            var admin = await _repository.GetByIdAsync(AdminId);

            if (admin == null || admin.Statu != Statu.Admin)
                return new Result(false, "Sisteme Kayıtlı Admin Bulunamadı.");

            admin.AktifMi = false;

            await _repository.UpdateAsync(admin);

            return new Result(true, "Admin Başarıyla Silindi.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> IsletmeOlustur(IsletmeOlusturParametre parametre)
    {
        try
        {
            var kullaniciAdiVarMi = await _kullaniciRepository.KullaniciAdiVarMiAsync(parametre.KullaniciAdi);

            if (kullaniciAdiVarMi != null)
                return new Result(false, "Sisteme Kayıtlı Kullanıcı Adı Bulunmaktadır.");

            var sifreKarmasi = _authService.HashPassword(parametre.Sifre);

            var isletme = new Kullanici
            {
                Ad = parametre.Ad,
                TelefonNo = parametre.TelefonNo,
                KullaniciAdi = parametre.KullaniciAdi,
                SifreKarmasi = sifreKarmasi,
                AbonelikSonlanmaTarihi = parametre.AbonelikSonlanmaTarihi,
                Statu = Statu.Isletme,
                AktifMi = true
            };

            await _repository.CreateAsync(isletme);

            return new Result(true, "İşletme Başarıyla Kaydedildi");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> IsletmeGuncelle(IsletmeGuncelleParametre parametre)
    {
        try
        {
            var isletme = await _repository.GetByIdAsync(parametre.IsletmeId);

            if (isletme == null || isletme.Statu != Statu.Isletme)
                return new Result(false, "Sisteme Kayıtlı İşletme Bulunamadı.");

            if (!string.IsNullOrWhiteSpace(parametre.Sifre))
            {
                var sifreKarmasi = _authService.HashPassword(parametre.Sifre);
                isletme.SifreKarmasi = sifreKarmasi;
            }

            isletme.Ad = parametre.Ad ?? isletme.Ad;
            isletme.TelefonNo = parametre.TelefonNo ?? isletme.TelefonNo;
            isletme.KullaniciAdi = parametre.KullaniciAdi ?? isletme.KullaniciAdi;
            isletme.AbonelikSonlanmaTarihi = parametre.AbonelikSonlanmaTarihi ?? isletme.AbonelikSonlanmaTarihi;

            await _repository.UpdateAsync(isletme);

            return new Result(true, "İşletme Başarıyla Güncellendi.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> IsletmeSil(int IsletmeId)
    {
        try
        {
            var isletme = await _repository.GetByIdAsync(IsletmeId);

            if (isletme == null || isletme.Statu != Statu.Isletme)
                return new Result(false, "Sisteme Kayıtlı İşletme Bulunamadı.");

            isletme.AktifMi = false;

            await _repository.UpdateAsync(isletme);

            return new Result(true, "İşletme Başarıyla Silindi.");

        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }
}
