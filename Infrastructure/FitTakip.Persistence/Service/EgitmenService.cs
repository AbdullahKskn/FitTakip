using System;
using FitTakip.Application.Common;
using FitTakip.Application.DTOs;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using FitTakip.Domain.Entities;

namespace FitTakip.Persistence.Service;

public class EgitmenService : IEgitmenService
{
    private readonly IRepository<Uye> _repositoryUye;
    private readonly IKullaniciRepository _kullaniciRepository;
    private readonly AuthService _authService;
    private readonly IRepository<Randevu> _repositoryRandevu;
    private readonly IRepository<Olcum> _repositoryOlcum;
    private readonly IRandevuRepository _randevuRepository;
    private readonly IOlcumRepository _olcumRepository;

    public EgitmenService(IRepository<Uye> repositoryUye, IKullaniciRepository kullaniciRepository, AuthService authService, IRepository<Randevu> repositoryRandevu, IRepository<Olcum> repositoryOlcum, IRandevuRepository randevuRepository, IOlcumRepository olcumRepository)
    {
        _repositoryUye = repositoryUye;
        _kullaniciRepository = kullaniciRepository;
        _authService = authService;
        _repositoryRandevu = repositoryRandevu;
        _repositoryOlcum = repositoryOlcum;
        _randevuRepository = randevuRepository;
        _olcumRepository = olcumRepository;
    }

    public async Task<Result> UyeOlustur(UyeOlusturParametre parametre)
    {
        try
        {
            var uye = new Uye
            {
                Ad = parametre.Ad,
                Soyad = parametre.Soyad,
                TelefonNo = parametre.TelefonNo,
                KalanDersSayisi = parametre.DersSayisi,
                IsletmeId = parametre.IsletmeId,
                EgitmenId = parametre.EgitmenId,
                AktifMi = true
            };

            await _repositoryUye.CreateAsync(uye);

            return new Result(true, "Üye Başarıyla Oluşturuldu");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> UyeGuncelle(UyeGuncelleParametre parametre)
    {
        try
        {
            var uye = await _repositoryUye.GetByIdAsync(parametre.UyeId);

            if (uye == null)
                return new Result(false, "Üye Bulunamadı.");

            uye.Ad = parametre.Ad ?? uye.Ad;
            uye.Soyad = parametre.Soyad ?? uye.Soyad;
            uye.TelefonNo = parametre.TelefonNo ?? uye.TelefonNo;
            uye.KalanDersSayisi = parametre.DersSayisi ?? uye.KalanDersSayisi;

            await _repositoryUye.UpdateAsync(uye);

            return new Result(true, "Üye Bilgileri Başarıyla Güncellendi.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> UyeSil(int UyeId)
    {
        try
        {
            var uye = await _repositoryUye.GetByIdAsync(UyeId);

            if (uye == null)
                return new Result(false, "Üye Bulunamadı.");

            uye.AktifMi = false;

            await _repositoryUye.UpdateAsync(uye);

            return new Result(true, "Üye Başarıyla Silindi");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> RandevuOlustur(RandevuOlusturParametre parametre)
    {
        try
        {
            var randevu = new Randevu
            {
                UyeId = parametre.UyeId,
                EgitmenId = parametre.EgitmenId,
                Tarih = parametre.Tarih,
                Aciklama = parametre.Aciklama
            };

            await _repositoryRandevu.CreateAsync(randevu);

            return new Result(true, "Randevu Başarıyla Eklendi");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> UyeyeAitRandevularıGetirPagination(int UyeId, int Baslangic, int Adet)
    {
        try
        {
            var randevular = await _randevuRepository.UyeyeAitRandevulariGetirAsync(UyeId, Baslangic, Adet);

            if (!randevular.Any())
                return new Result(false, "Üyeye Ait Randevu Bulunamadı.");

            var randevuDto = randevular.Select(s => new RandevuDto
            {
                RandevuId = s.RandevuId,
                UyeId = s.UyeId,
                UyeAdi = s.Uye.Ad + " " + s.Uye.Soyad,
                EgitmenId = s.EgitmenId,
                EgitmenAdi = s.Egitmen.Ad + " " + s.Egitmen.Soyad,
                Tarih = s.Tarih,
                Aciklama = s.Aciklama,
            }).ToList();

            return new Result(true, "Üyeye Ait Randevuları Getirme Başarılı", randevuDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> GunlukRandevuGetir(int EgitmenId, DateTime Tarih)
    {
        try
        {
            var randevular = await _randevuRepository.GunlukRandevuGetirAsync(EgitmenId, Tarih);

            if (!randevular.Any())
                return new Result(false, "Seçili Tarihte Randevunuz Bulunmamaktadır.");

            var randevuDto = randevular.Select(s => new RandevuDto
            {
                RandevuId = s.RandevuId,
                UyeId = s.UyeId,
                UyeAdi = s.Uye.Ad + " " + s.Uye.Soyad,
                Tarih = s.Tarih,
                Aciklama = s.Aciklama,
            }).ToList();

            return new Result(true, "Eğitmene Ait Günlük Randevuları Getirme Başarılı", randevuDto);

        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> OlcumOlustur(OlcumOlusturParametre parametre)
    {
        try
        {
            var olcum = new Olcum
            {
                UyeId = parametre.UyeId,
                Tarih = parametre.Tarih,
                Boy = parametre.Boy,
                Kilo = parametre.Kilo,
                Omuz = parametre.Omuz,
                Gogus = parametre.Gogus,
                SagKol = parametre.SagKol,
                SolKol = parametre.SolKol,
                Bel = parametre.Bel,
                Kalca = parametre.Kalca,
                SagBacak = parametre.SagBacak,
                SolBacak = parametre.SolBacak,
            };

            await _repositoryOlcum.CreateAsync(olcum);

            return new Result(true, "Üyeye Ait Ölçüm Başarıyla Eklendi");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> UyeOlcumGetirPagination(int UyeId, int Baslangic, int Adet)
    {
        try
        {
            var olcumler = await _olcumRepository.UyeyeAitOlcumleriGetirAsync(UyeId, Baslangic, Adet);

            if (!olcumler.Any())
                return new Result(false, "Üyeye Ait Ölçüm Bulunamadı.");

            var olcumDto = olcumler.Select(s => new OlcumDto
            {
                OlcumId = s.OlcumId,
                UyeId = s.UyeId,
                UyeAdi = s.Uye.Ad + " " + s.Uye.Soyad,
                Tarih = s.Tarih,
                Boy = s.Boy,
                Kilo = s.Kilo,
                Omuz = s.Omuz,
                Gogus = s.Gogus,
                SagKol = s.SagKol,
                SolKol = s.SolKol,
                Bel = s.Bel,
                Kalca = s.Kalca,
                SagBacak = s.SagBacak,
                SolBacak = s.SolBacak,
            }).ToList();

            return new Result(true, "Üyeye Ait Ölçüm Getirme Başarılı.", olcumDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }
}
