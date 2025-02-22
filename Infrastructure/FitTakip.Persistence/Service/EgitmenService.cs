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
    private readonly IRepository<Paket> _repositoryPaket;
    private readonly IKullaniciRepository _kullaniciRepository;
    private readonly AuthService _authService;
    private readonly IRepository<Randevu> _repositoryRandevu;
    private readonly IRepository<Olcum> _repositoryOlcum;
    private readonly IRandevuRepository _randevuRepository;
    private readonly IOlcumRepository _olcumRepository;
    private readonly IPaketRepository _paketRepository;

    public EgitmenService(IRepository<Uye> repositoryUye, IKullaniciRepository kullaniciRepository, AuthService authService, IRepository<Randevu> repositoryRandevu, IRepository<Olcum> repositoryOlcum, IRandevuRepository randevuRepository, IOlcumRepository olcumRepository, IRepository<Paket> repositoryPaket, IPaketRepository paketRepository)
    {
        _repositoryUye = repositoryUye;
        _kullaniciRepository = kullaniciRepository;
        _authService = authService;
        _repositoryRandevu = repositoryRandevu;
        _repositoryOlcum = repositoryOlcum;
        _randevuRepository = randevuRepository;
        _olcumRepository = olcumRepository;
        _repositoryPaket = repositoryPaket;
        _paketRepository = paketRepository;
    }

    public async Task<Result> UyeOlustur(UyeOlusturParametre parametre)
    {
        try
        {
            var paket = await _repositoryPaket.GetByIdAsync(parametre.PaketId);

            if (paket == null)
                return new Result(false, "Paket Bulunamadı");

            var uye = new Uye
            {
                Ad = parametre.Ad,
                Soyad = parametre.Soyad,
                TelefonNo = parametre.TelefonNo,
                PaketId = parametre.PaketId,
                KalanDersSayisi = paket.DersSayisi,
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

    public async Task<Result> UyeyePaketEkle(UyeyePaketEkleParametre parametre)
    {
        try
        {
            var uye = await _repositoryUye.GetByIdAsync(parametre.UyeId);
            var paket = await _repositoryPaket.GetByIdAsync(parametre.PaketId);

            if (uye.KalanDersSayisi > 0)
                return new Result(false, "Üyenin Bir Önceki Paketi Bitmeden Yeni Paket Tanımlanamaz");

            uye.PaketId = parametre.PaketId;
            uye.KalanDersSayisi = paket.DersSayisi;

            await _repositoryUye.UpdateAsync(uye);

            return new Result(true, "Üyeye Paket Başarıyla Tanımlanmıştır.");
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
            var uye = await _repositoryUye.GetByIdAsync(parametre.UyeId);

            var randevu = new Randevu
            {
                UyeId = parametre.UyeId,
                EgitmenId = parametre.EgitmenId,
                Tarih = parametre.Tarih,
                Aciklama = parametre.Aciklama
            };

            uye.KalanDersSayisi -= 1;

            await _repositoryRandevu.CreateAsync(randevu);
            await _repositoryUye.UpdateAsync(uye);

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

    public async Task<Result> PaketleriGetir(int IsletmeId)
    {
        try
        {
            var paketler = await _paketRepository.IsletmeyeAitPaketleriGetirAsync(IsletmeId);

            if (!paketler.Any())
                return new Result(false, "İşletmeye Ait Paket Bulunamadı");

            var paketDto = paketler.Select(s => new PaketDto
            {
                PaketId = s.PaketId,
                IsletmeId = s.IsletmeId,
                Aciklama = s.Aciklama,
                Tutar = s.Tutar,
                DersSayisi = s.DersSayisi,
            }).ToList();

            return new Result(true, "İşletmeye Ait Paketleri Getirme Başarılı", paketDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }
}
