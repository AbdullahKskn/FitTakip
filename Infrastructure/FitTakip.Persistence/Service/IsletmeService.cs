using System;
using System.Net.Sockets;
using FitTakip.Application.Common;
using FitTakip.Application.DTOs;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using FitTakip.Domain.Entities;

namespace FitTakip.Persistence.Service;

public class IsletmeService : IIsletmeService
{
    private readonly IRepository<Isletme> _repositoryIsletme;
    private readonly IRepository<Egitmen> _repositoryEgitmen;
    private readonly IRepository<Gelir> _repositoryGelir;
    private readonly IRepository<Gider> _repositoryGider;
    private readonly IRepository<Paket> _repositoryPaket;
    private readonly IKullaniciRepository _kullaniciRepository;
    private readonly IGelirRepository _gelirRepository;
    private readonly IGiderRepository _giderRepository;
    private readonly IRandevuRepository _randevuRepository;
    private readonly IPaketRepository _paketRepository;
    private readonly AuthService _authService;

    public IsletmeService(IRepository<Isletme> repositoryIsletme, IKullaniciRepository kullaniciRepository, AuthService authService, IRepository<Gelir> repositoryGelir, IGelirRepository gelirRepository, IRepository<Gider> repositoryGider, IGiderRepository giderRepository, IRepository<Egitmen> repositoryEgitmen, IRandevuRepository randevuRepository, IRepository<Paket> repositoryPaket, IPaketRepository paketRepository)
    {
        _repositoryIsletme = repositoryIsletme;
        _kullaniciRepository = kullaniciRepository;
        _authService = authService;
        _repositoryGelir = repositoryGelir;
        _gelirRepository = gelirRepository;
        _repositoryGider = repositoryGider;
        _giderRepository = giderRepository;
        _repositoryEgitmen = repositoryEgitmen;
        _randevuRepository = randevuRepository;
        _repositoryPaket = repositoryPaket;
        _paketRepository = paketRepository;
    }

    public async Task<Result> EgitmenOlustur(EgitmenOlusturParametre parametre)
    {
        try
        {
            var kullaniciAdiVarMi = await _kullaniciRepository.KullaniciAdiVarMiAsync(parametre.KullaniciAdi);

            if (kullaniciAdiVarMi == true)
                return new Result(false, "Sisteme Kayıtlı Bu Kullanıcı Adı Bulunmaktadır.");

            var sifreKarmasi = _authService.HashPassword(parametre.Sifre);

            var egitmen = new Egitmen
            {
                Ad = parametre.Ad,
                Soyad = parametre.Soyad,
                TelefonNo = parametre.TelefonNo,
                KullaniciAdi = parametre.KullaniciAdi,
                SifreKarmasi = sifreKarmasi,
                IsletmeId = parametre.IsletmeId,
                AktifMi = true
            };

            await _repositoryEgitmen.CreateAsync(egitmen);

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
            var egitmen = await _repositoryEgitmen.GetByIdAsync(parametre.EgitmenId);

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

            await _repositoryEgitmen.UpdateAsync(egitmen);

            return new Result(true, "Eğitmen Başarıyla Güncellendi.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> EgitmenSil(long EgitmenId)
    {
        try
        {
            var egitmen = await _repositoryEgitmen.GetByIdAsync(EgitmenId);

            if (egitmen == null)
                return new Result(false, "Eğitmen Bulunamadı");

            egitmen.AktifMi = false;

            await _repositoryEgitmen.UpdateAsync(egitmen);

            return new Result(true, "Eğitmen Başarıyla Silindi");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> TumEgitmenleriGetir(long IsletmeId)
    {
        try
        {
            var egitmenler = await _kullaniciRepository.TumEgitmenleriGetirAsync(IsletmeId);

            if (!egitmenler.Any())
                return new Result(false, "İşletmeye Kayıtlı Eğitmen Bulunamadı");

            var egitmenDto = egitmenler.Select(s => new EgitmenDto
            {
                EgitmenId = s.EgitmenId,
                Ad = s.Ad,
                Soyad = s.Soyad
            }).OrderBy(o => o.Ad).ToList();

            return new Result(true, "İşletmeye Kayıtlı Eğitmenleri Getirme Başarılı.", egitmenDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> TumUyeleriGetir(long IsletmeId)
    {
        try
        {
            var uyeler = await _kullaniciRepository.TumUyeleriGetirAsync(IsletmeId);

            if (!uyeler.Any())
                return new Result(false, "İşletmeye Kayıtlı Üye Bulunamadı.");

            var uyeDto = uyeler.Select(s => new UyeDto
            {
                UyeId = s.UyeId,
                Ad = s.Ad,
                Soyad = s.Soyad
            }).ToList();

            return new Result(true, "İşletmeye Kayıtlı Eğitmenleri Getirme Başarılı.", uyeDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> EgitmenleriGetirPagination(long IsletmeId, int Baslangic, int Adet)
    {
        try
        {
            var egitmenler = await _kullaniciRepository.EgitmenleriGetirPaginationAsync(IsletmeId, Baslangic, Adet);

            if (!egitmenler.Any())
                return new Result(false, "İşletmeye Kayıtlı Eğitmen Bulunmamaktadır.");

            var egitmenDto = egitmenler.Select(s => new EgitmenDto
            {
                EgitmenId = s.EgitmenId,
                Ad = s.Ad,
                Soyad = s.Soyad,
                TelefonNo = s.TelefonNo,
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

    public async Task<Result> UyeleriGetirPagination(long IsletmeId, int Baslangic, int Adet)
    {
        try
        {
            var uyeler = await _kullaniciRepository.UyeleriGetirPaginationAsync(IsletmeId, Baslangic, Adet);

            if (!uyeler.Any())
                return new Result(false, "İşletmeye Kayıtlı Üye Bulunmamaktadır.");

            var uyeDto = uyeler.Select(s => new UyeDto
            {
                UyeId = s.UyeId,
                Ad = s.Ad,
                Soyad = s.Soyad,
                TelefonNo = s.TelefonNo,
                KalanDersSayisi = s.KalanDersSayisi,
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

    public async Task<Result> GelirOlustur(GelirOlusturParametre parametre)
    {
        try
        {
            var gelir = new Gelir
            {
                IsletmeId = parametre.IsletmeId,
                Aciklama = parametre.Aciklama,
                Tarih = parametre.Tarih,
                Tutar = parametre.Tutar
            };

            await _repositoryGelir.CreateAsync(gelir);

            return new Result(true, "Gelir Başarıyla Kaydedildi");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> TumGelirlerToplami(long IsletmeId)
    {
        try
        {
            var gelirToplami = await _gelirRepository.TumGelirlerToplamiAsync(IsletmeId);

            return new Result(true, "Tüm Gelirlerin Toplamını Getirme Başarılı", gelirToplami);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> GelirleriTariheGöreGetirPagination(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet)
    {
        try
        {
            var gelirler = await _gelirRepository.GelirleriTariheGöreGetirPaginationAsync(IsletmeId, BaslangicTarihi, BitisTarihi, Baslangic, Adet);

            if (!gelirler.Any())
                return new Result(false, "Belirtilen Tarihler Arasında Gelir Kaydı Bulunamadı");

            var gelirDto = gelirler.Select(s => new GelirDto
            {
                GelirId = s.GelirId,
                IsletmeId = s.IsletmeId,
                Aciklama = s.Aciklama,
                Tarih = s.Tarih,
                Tutar = s.Tutar,
            }).ToList();

            return new Result(true, "Belirtilen Tarihler Arasındaki Gelirleri Getirme Başarılı", gelirDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> GelirleriTariheGöreTopla(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi)
    {
        try
        {
            var gelirlerToplamı = await _gelirRepository.GelirleriTariheGöreToplaAsync(IsletmeId, BaslangicTarihi, BitisTarihi);

            return new Result(true, "Belirtilen Tarihler Arasındaki Gelirlerin Toplamını Getirme Başarılı", gelirlerToplamı);

        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> GiderOlustur(GiderOlusturParametre parametre)
    {
        try
        {
            var gider = new Gider
            {
                IsletmeId = parametre.IsletmeId,
                Aciklama = parametre.Aciklama,
                Tarih = parametre.Tarih,
                Tutar = parametre.Tutar
            };

            await _repositoryGider.CreateAsync(gider);

            return new Result(true, "Gider Oluşturuldu");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> TumGiderlerToplami(long IsletmeId)
    {
        try
        {
            var giderToplami = await _giderRepository.TumGiderlerToplamiAsync(IsletmeId);

            return new Result(true, "Tüm Giderlerin Toplamını Getirme Başarılı", giderToplami);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> GiderleriTariheGöreGetirPagination(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet)
    {
        try
        {
            var giderler = await _giderRepository.GiderleriTariheGöreGetirPaginationAsync(IsletmeId, BaslangicTarihi, BitisTarihi, Baslangic, Adet);

            if (!giderler.Any())
                return new Result(false, "Belirtilen Tarihler Arasında Gider Kaydı Bulunamadı");

            var giderDto = giderler.Select(s => new GiderDto
            {
                GiderId = s.GiderId,
                IsletmeId = s.IsletmeId,
                Aciklama = s.Aciklama,
                Tarih = s.Tarih,
                Tutar = s.Tutar,
            }).ToList();

            return new Result(true, "Belirtilen Tarihler Arasındaki Giderleri Getirme Başarılı", giderDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> GiderleriTariheGöreTopla(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi)
    {
        try
        {
            var giderlerToplamı = await _giderRepository.GiderleriTariheGöreToplaAsync(IsletmeId, BaslangicTarihi, BitisTarihi);

            return new Result(true, "Belirtilen Tarihler Arasındaki Giderlerin Toplamını Getirme Başarılı", giderlerToplamı);

        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> TumGelirGiderToplami(long IsletmeId)
    {
        try
        {
            var gelir = await _gelirRepository.TumGelirlerToplamiAsync(IsletmeId);
            var gider = await _giderRepository.TumGiderlerToplamiAsync(IsletmeId);

            var sonuc = gelir - gider;
            return new Result(true, "Toplam Gelir Gider Sonucu Getirme Başarılı", sonuc);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> PotansiyelMusterileriGetirPagination(long IsletmeId, int Baslangic, int Adet)
    {
        try
        {
            var potansiyelMusteriler = await _kullaniciRepository.PotansiyelMusterileriGetirPaginationAsync(IsletmeId, Baslangic, Adet);

            if (!potansiyelMusteriler.Any())
                return new Result(false, "Potansiyel Müşteri Bulunamadı.");

            var uyeDurum = new List<object>();

            foreach (var s in potansiyelMusteriler)
            {
                var sonDersTarihi = await _randevuRepository.SonRandevuGetirAsync(s.UyeId);
                var gecenGunSayisi = (DateTime.Now - sonDersTarihi.GetValueOrDefault()).Days; // Null kontrolü

                uyeDurum.Add(new
                {
                    UyeId = s.UyeId,
                    Ad = s.Ad,
                    Soyad = s.Soyad,
                    TelefonNo = s.TelefonNo,
                    SonDersTarihi = sonDersTarihi,
                    GecenGunSayisi = gecenGunSayisi
                });
            }

            return new Result(true, "Başarıyla getirildi.", uyeDurum);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> PaketEkle(PaketEkleParametre parametre)
    {
        try
        {
            var paket = new Paket
            {
                IsletmeId = parametre.IsletmeId,
                Aciklama = parametre.Aciklama,
                Tutar = parametre.Tutar,
                DersSayisi = parametre.DersSayisi,
                AktifMi = true,
            };

            await _repositoryPaket.CreateAsync(paket);

            return new Result(true, "Paket Başarıyla Eklendi");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> PaketSil(long PaketId)
    {
        try
        {
            var paket = await _repositoryPaket.GetByIdAsync(PaketId);

            if (paket == null)
                return new Result(false, "İşletmeye Ait Paket Bulunamadı");

            paket.AktifMi = false;

            await _repositoryPaket.UpdateAsync(paket);

            return new Result(true, "İşletmeye Ait Paket Başarıyla Silindi.");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> PaketleriGetir(long IsletmeId)
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

    public async Task<Result> EgitmenTariheGöreDersSayisiGetir(long EgitmenId, DateTime BaslangicTarih, DateTime BitisTarih)
    {
        try
        {
            var dersSayisi = await _randevuRepository.EgitmenTariheGöreDersSayisiGetirAsync(EgitmenId, BaslangicTarih, BitisTarih);

            return new Result(true, "Tarihe Göre Ders Sayısı Getirme Başarılı", dersSayisi);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    public async Task<Result> EgitmenMaasHesapla(long EgitmenId, DateTime BaslangicTarih, DateTime BitisTarih, int KomisyonOrani)
    {
        try
        {
            var randevular = await _randevuRepository.EgitmenTariheGöreTumRandeculariGetirAsync(EgitmenId, BaslangicTarih, BitisTarih);

            if (!randevular.Any())
                return new Result(false, "Eğitmene Ait Belirtilen Tarihler Arasında Randevu Bulunmamaktadır.");

            decimal toplamMaas = 0;

            foreach (var randevu in randevular)
            {
                // Dersin ait olduğu paketi al
                var paket = randevu.Uye?.Paket;
                if (paket == null) continue; // Paket veya ders sayısı geçersizse atla

                // Ders başına ücret hesapla
                decimal dersBasinaUcret = paket.Tutar / paket.DersSayisi;

                // Eğitmenin alacağı komisyon hesapla
                decimal kazanc = dersBasinaUcret * (Convert.ToDecimal(KomisyonOrani) / 100);

                toplamMaas += kazanc;
            }

            return new Result(true, "Eğitmen Maaşı Başarıyla Hesaplandı", toplamMaas);
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
            var isletme = await _repositoryIsletme.GetByIdAsync(parametre.Id);

            if (parametre.Sifre != parametre.SifreDogrulama)
                return new Result(false, "Şifre Uyuşmamaktadır");

            var sifreKarmasi = _authService.HashPassword(parametre.Sifre);

            isletme.SifreKarmasi = sifreKarmasi;

            await _repositoryIsletme.UpdateAsync(isletme);

            return new Result(true, "Şifre Değiştirme Başarılı");
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }
}
