using System;
using FitTakip.Application.Common;
using FitTakip.Application.DTOs;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using FitTakip.Domain.Entities;

namespace FitTakip.Persistence.Service;

public class AdminService : IAdminService
{
    private readonly IRepository<Admin> _repositoryAdmin;
    private readonly IRepository<Isletme> _repositoryIsletme;
    private readonly AuthService _authService;
    private readonly IKullaniciRepository _kullaniciRepository;

    public AdminService(IKullaniciRepository kullaniciRepository, AuthService authService, IRepository<Admin> repositoryAdmin, IRepository<Isletme> repositoryIsletme)
    {
        _kullaniciRepository = kullaniciRepository;
        _authService = authService;
        _repositoryAdmin = repositoryAdmin;
        _repositoryIsletme = repositoryIsletme;
    }

    public async Task<Result> AdminOlustur(AdminOlusturParametre parametre)
    {
        try
        {
            var kullaniciAdiVarMi = await _kullaniciRepository.KullaniciAdiVarMiAsync(parametre.KullaniciAdi);

            if (kullaniciAdiVarMi == true)
                return new Result(false, "Sisteme Kayıtlı Bu Kullanıcı Adı Bulunmaktadır.");

            var sifreKarmasi = _authService.HashPassword(parametre.Sifre);

            var admin = new Admin
            {
                Ad = parametre.Ad,
                Soyad = parametre.Soyad,
                KullaniciAdi = parametre.KullaniciAdi,
                SifreKarmasi = sifreKarmasi,
                AktifMi = true,
            };

            await _repositoryAdmin.CreateAsync(admin);

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
            var admin = await _repositoryAdmin.GetByIdAsync(parametre.AdminId);

            if (admin == null)
                return new Result(false, "Sisteme Kayıtlı Admin Bulunamadı.");

            if (!string.IsNullOrWhiteSpace(parametre.KullaniciAdi) && parametre.KullaniciAdi != admin.KullaniciAdi)
            {
                var kullaniciAdiVarMi = await _kullaniciRepository.KullaniciAdiVarMiAsync(parametre.KullaniciAdi);

                if (kullaniciAdiVarMi == true)
                    return new Result(false, "Sisteme Kayıtlı Bu Kullanıcı Adı Bulunmaktadır.");
            }
            if (!string.IsNullOrWhiteSpace(parametre.Sifre))
            {
                var sifreKarmasi = _authService.HashPassword(parametre.Sifre);
                admin.SifreKarmasi = sifreKarmasi;
            }

            admin.Ad = parametre.Ad ?? admin.Ad;
            admin.Soyad = parametre.Soyad ?? admin.Soyad;
            admin.KullaniciAdi = parametre.KullaniciAdi ?? admin.KullaniciAdi;

            await _repositoryAdmin.UpdateAsync(admin);

            return new Result(true, "Admin Başarıyla Güncellendi.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> AdminSil(long AdminId)
    {
        try
        {
            var admin = await _repositoryAdmin.GetByIdAsync(AdminId);

            if (admin == null)
                return new Result(false, "Sisteme Kayıtlı Admin Bulunamadı.");

            admin.AktifMi = false;

            await _repositoryAdmin.UpdateAsync(admin);

            return new Result(true, "Admin Başarıyla Silindi.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> AdminleriGetirPagination(int Baslangic, int Adet)
    {
        try
        {
            var adminler = await _kullaniciRepository.AdminleriGetirPaginationAsync(Baslangic, Adet);

            if (!adminler.Any())
                return new Result(false, "Sisteme Kayıtlı Admin Bulunamadı");

            var adminDto = adminler.Select(s => new AdminDto
            {
                AdminId = s.AdminId,
                Ad = s.Ad,
                Soyad = s.Soyad,
            }).ToList();

            return new Result(true, "Adminleri Getirme Başarılı", adminDto);
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

            if (kullaniciAdiVarMi == true)
                return new Result(false, "Sisteme Kayıtlı Bu Kullanıcı Adı Bulunmaktadır.");

            var sifreKarmasi = _authService.HashPassword(parametre.Sifre);
            var abonelikSonlanmaTarihi = DateTime.Now.AddYears(parametre.AbonelikYilEkle);

            var isletme = new Isletme
            {
                Ad = parametre.Ad,
                TelefonNo = parametre.TelefonNo,
                KullaniciAdi = parametre.KullaniciAdi,
                SifreKarmasi = sifreKarmasi,
                AbonelikSonlanmaTarihi = abonelikSonlanmaTarihi,
                AktifMi = true
            };

            await _repositoryIsletme.CreateAsync(isletme);

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
            var isletme = await _repositoryIsletme.GetByIdAsync(parametre.IsletmeId);

            if (isletme == null)
                return new Result(false, "Sisteme Kayıtlı İşletme Bulunamadı.");

            if (!string.IsNullOrWhiteSpace(parametre.KullaniciAdi) && parametre.KullaniciAdi != isletme.KullaniciAdi)
            {
                var kullaniciAdiVarMi = await _kullaniciRepository.KullaniciAdiVarMiAsync(parametre.KullaniciAdi);

                if (kullaniciAdiVarMi == true)
                    return new Result(false, "Sisteme Kayıtlı Bu Kullanıcı Adı Bulunmaktadır.");
            }

            if (!string.IsNullOrWhiteSpace(parametre.Sifre))
            {
                var sifreKarmasi = _authService.HashPassword(parametre.Sifre);
                isletme.SifreKarmasi = sifreKarmasi;
            }

            isletme.Ad = parametre.Ad ?? isletme.Ad;
            isletme.TelefonNo = parametre.TelefonNo ?? isletme.TelefonNo;
            isletme.KullaniciAdi = parametre.KullaniciAdi ?? isletme.KullaniciAdi;

            await _repositoryIsletme.UpdateAsync(isletme);

            return new Result(true, "İşletme Başarıyla Güncellendi.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> IsletmeSil(long IsletmeId)
    {
        try
        {
            var isletme = await _repositoryIsletme.GetByIdAsync(IsletmeId);

            if (isletme == null)
                return new Result(false, "Sisteme Kayıtlı İşletme Bulunamadı.");

            isletme.AktifMi = false;

            await _repositoryIsletme.UpdateAsync(isletme);

            return new Result(true, "İşletme Başarıyla Silindi.");

        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> IsletmeyeKullanımSuresiEkle(IsletmeyeKullanımSuresiEkleParametre parametre)
    {
        try
        {
            var isletme = await _repositoryIsletme.GetByIdAsync(parametre.IsletmeId);

            if (isletme == null)
                return new Result(false, "İşletme Bulunamadı.");

            if (isletme.AbonelikSonlanmaTarihi > DateTime.Now)
                isletme.AbonelikSonlanmaTarihi = isletme.AbonelikSonlanmaTarihi.AddYears(parametre.EklenecekYil);

            if (isletme.AbonelikSonlanmaTarihi < DateTime.Now)
                isletme.AbonelikSonlanmaTarihi = DateTime.Now.AddYears(parametre.EklenecekYil);

            await _repositoryIsletme.UpdateAsync(isletme);

            return new Result(true, "İşletmenin abonelik süresi başarıyla uzatıldı.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> IsletmeleriGetirPagination(int Baslangic, int Adet)
    {
        try
        {
            var isletmeler = await _kullaniciRepository.IsletmeleriGetirPaginationAsync(Baslangic, Adet);

            if (!isletmeler.Any())
                return new Result(false, "Sisteme Kayıtlı İşletme Bulunamadı");

            var isletmeDto = isletmeler.Select(s => new IsletmeDto
            {
                IsletmeId = s.IsletmeId,
                Ad = s.Ad,
                TelefonNo = s.TelefonNo,
                AbonelikSonlanmaTarihi = s.AbonelikSonlanmaTarihi,
                AktifMi = s.AktifMi
            }).OrderBy(o => o.Ad).ToList();

            return new Result(true, "İşletmeleri Getirme Başarılı", isletmeDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> SifreDegistir(SifreDegistirParametre parametre)
    {
        try
        {
            var admin = await _repositoryAdmin.GetByIdAsync(parametre.Id);

            if (parametre.Sifre != parametre.SifreDogrulama)
                return new Result(false, "Şifre Uyuşmamaktadır");

            var sifreKarmasi = _authService.HashPassword(parametre.Sifre);

            admin.SifreKarmasi = sifreKarmasi;

            await _repositoryAdmin.UpdateAsync(admin);

            return new Result(true, "Şifre Değiştirme Başarılı");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }
}
