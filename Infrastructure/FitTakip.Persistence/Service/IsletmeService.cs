using System;
using FitTakip.Application.Common;
using FitTakip.Application.DTOs;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using FitTakip.Domain.Entities;
using FitTakip.Domain.Enum;

namespace FitTakip.Persistence.Service;

public class IsletmeService : IIsletmeService
{
    private readonly IRepository<Kullanici> _repository;
    private readonly IKullaniciRepository _kullaniciRepository;
    private readonly AuthService _authService;

    public IsletmeService(IRepository<Kullanici> repository, IKullaniciRepository kullaniciRepository, AuthService authService)
    {
        _repository = repository;
        _kullaniciRepository = kullaniciRepository;
        _authService = authService;
    }

    public async Task<Result> EgitmenOlustur(EgitmenOlusturParametre parametre)
    {
        try
        {
            var kullaniciAdiVarMi = await _kullaniciRepository.KullaniciAdiVarMiAsync(parametre.KullaniciAdi);

            if (kullaniciAdiVarMi != null)
                return new Result(false, "Sisteme Kayıtlı Bu Kullanıcı Adı Bulunmaktadır.");

            var sifreKarmasi = _authService.HashPassword(parametre.Sifre);

            var egitmen = new Kullanici
            {
                Ad = parametre.Ad,
                Soyad = parametre.Soyad,
                TelefonNo = parametre.TelefonNo,
                KullaniciAdi = parametre.KullaniciAdi,
                SifreKarmasi = sifreKarmasi,
                IsletmeId = parametre.IsletmeId,
                Statu = Statu.Egitmen,
                AktifMi = true
            };

            await _repository.CreateAsync(egitmen);

            return new Result(true, "Eğitmen Başarıyla Oluşturuldu.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> EgitmenGuncelle(EgitmenGuncelleParametre parametre)
    {
        try
        {
            var egitmen = await _repository.GetByIdAsync(parametre.EgitmenId);

            if (egitmen == null)
                return new Result(false, "Eğitmen Bulunamadı.");

            if (!string.IsNullOrWhiteSpace(parametre.KullaniciAdi) && parametre.KullaniciAdi != egitmen.KullaniciAdi)
            {
                var kullaniciAdiVarMi = await _kullaniciRepository.KullaniciAdiVarMiAsync(parametre.KullaniciAdi);

                if (kullaniciAdiVarMi != null)
                    return new Result(false, "Sisteme Kayıtlı Bu Kullanıcı Adı Bulunmaktadır.");
            }

            if (!string.IsNullOrWhiteSpace(parametre.Sifre))
            {
                var sifreKarmasi = _authService.HashPassword(parametre.Sifre);
                egitmen.SifreKarmasi = sifreKarmasi;
            }

            egitmen.Ad = parametre.Ad ?? egitmen.Ad;
            egitmen.Soyad = parametre.Soyad ?? egitmen.Soyad;
            egitmen.TelefonNo = parametre.TelefonNo ?? egitmen.TelefonNo;
            egitmen.KullaniciAdi = parametre.KullaniciAdi ?? egitmen.KullaniciAdi;

            await _repository.UpdateAsync(egitmen);

            return new Result(true, "Eğitmen Başarıyla Güncellendi.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> EgitmenSil(int EgitmenId)
    {
        try
        {
            var egitmen = await _repository.GetByIdAsync(EgitmenId);

            if (egitmen == null)
                return new Result(false, "Eğitmen Bulunamadı");

            egitmen.AktifMi = false;

            await _repository.UpdateAsync(egitmen);

            return new Result(true, "Eğitmen Başarıyla Silindi");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> TumEgitmenleriGetir(int IsletmeId)
    {
        try
        {
            var egitmenler = await _kullaniciRepository.TumEgitmenleriGetirAsync(IsletmeId);

            if (!egitmenler.Any())
                return new Result(false, "İşletmeye Kayıtlı Eğitmen Bulunamadı");

            var egitmenDto = egitmenler.Select(s => new EgitmenDto
            {
                KullaniciId = s.KullaniciId,
                Ad = s.Ad,
                Soyad = s.Soyad,
                TelefonNo = s.TelefonNo,
                DogumTarihi = s.DogumTarihi,
                IsletmeId = s.IsletmeId,
                AktifMi = s.AktifMi,
            }).OrderBy(o => o.Ad).ToList();

            return new Result(true, "İşletmeye Kayıtlı Eğitmenleri Getirme Başarılı.", egitmenDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> EgitmenleriGetirPagination(int IsletmeId, int Baslangic, int Adet)
    {
        try
        {
            var egitmenler = await _kullaniciRepository.EgitmenleriGetirPaginationAsync(IsletmeId, Baslangic, Adet);

            if (!egitmenler.Any())
                return new Result(false, "İşletmeye Kayıtlı Eğitmen Bulunmamaktadır.");

            var egitmenDto = egitmenler.Select(s => new EgitmenDto
            {
                KullaniciId = s.KullaniciId,
                Ad = s.Ad,
                Soyad = s.Soyad,
                TelefonNo = s.TelefonNo,
                DogumTarihi = s.DogumTarihi,
                IsletmeId = s.IsletmeId,
                AktifMi = s.AktifMi,
            }).OrderBy(o => o.Ad).ToList();

            return new Result(true, "İşletmeye Kayıtlı Eğitmen Getirme Başarılı.", egitmenDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> UyeleriGetirPagination(int IsletmeId, int Baslangic, int Adet)
    {
        try
        {
            var uyeler = await _kullaniciRepository.UyeleriGetirPaginationAsync(IsletmeId, Baslangic, Adet);

            if (!uyeler.Any())
                return new Result(false, "İşletmeye Kayıtlı Üye Bulunmamaktadır.");

            var uyeDto = uyeler.Select(s => new UyeDto
            {
                KullaniciId = s.KullaniciId,
                Ad = s.Ad,
                Soyad = s.Soyad,
                TelefonNo = s.TelefonNo,
                KalanDersSayisi = s.KalanDersSayisi,
                DogumTarihi = s.DogumTarihi,
                IsletmeId = s.IsletmeId,
                EgitmenId = s.EgitmenId,
                EgitmenAdı = s.Egitmen.Ad + " " + s.Egitmen.Soyad,
                AktifMi = s.AktifMi,
            }).OrderBy(o => o.Ad).ToList();

            return new Result(true, "İşletmeye Kayıtlı Üye Getirme Başarılı.", uyeDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }
}
