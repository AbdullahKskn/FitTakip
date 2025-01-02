using System;
using FitTakip.Application.Common;
using FitTakip.Application.DTOs;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using FitTakip.Domain.Entities;
using FitTakip.Domain.Enum;

namespace FitTakip.Persistence.Service;

public class LoginService : ILoginService
{
    private readonly ILoginRepository _loginRepository;
    private readonly AuthService _authService;
    private readonly IRepository<Kullanici> _repository;

    public LoginService(ILoginRepository loginRepository, AuthService authService, IRepository<Kullanici> repository)
    {
        _loginRepository = loginRepository;
        _authService = authService;
        _repository = repository;
    }

    public async Task<Result> GirisYap(GirisYapParametre parametre)
    {
        try
        {
            var kullanici = await _loginRepository.KullaniciAdınaGöreGetir(parametre.KullaniciAdi);

            if (kullanici == null)
                return new Result(false, "Böyle Bir Kullanıcı Bulunamadı");

            var sifreDogruMu = _authService.VerifyPassword(parametre.Sifre, kullanici.SifreKarmasi);

            if (!sifreDogruMu)
                return new Result(false, "Geçersiz Şifre");

            if (kullanici.Statu == Statu.Isletme && kullanici.AbonelikSonlanmaTarihi < DateTime.Now)
                return new Result(false, "İşletmeye Ait Abonelik Süresi Bitmiştir.");

            if (kullanici.Statu == Statu.Egitmen || kullanici.Statu == Statu.Uye)
            {
                if (kullanici.IsletmeId == null)
                    return new Result(false, "Bağlı Olunan İşletme Bilgisi Bulunamadı.");

                var isletme = await _repository.GetByIdAsync(kullanici.IsletmeId.Value);

                if (isletme == null)
                    return new Result(false, "Bağlı Olunan İşletme Bulunamadı.");

                if (isletme.AbonelikSonlanmaTarihi < DateTime.Now)
                    return new Result(false, "Bağlı Olunan İşletmenin Abonelik Süresi Bitmiştir.");
            }

            switch (kullanici.Statu)
            {
                case Statu.Admin:
                    var adminDto = new AdminDto
                    {
                        KullaniciId = kullanici.KullaniciId,
                        Ad = kullanici.Ad,
                        Soyad = kullanici.Soyad,
                        TelefonNo = kullanici.TelefonNo,
                        DogumTarihi = kullanici.DogumTarihi
                    };
                    return new Result(true, "Giriş Başarılı", adminDto);

                case Statu.Isletme:
                    var isletmeDto = new IsletmeDto
                    {
                        KullaniciId = kullanici.KullaniciId,
                        Ad = kullanici.Ad,
                        TelefonNo = kullanici.TelefonNo,
                        AbonelikSonlanmaTarihi = kullanici.AbonelikSonlanmaTarihi,
                        AktifMi = kullanici.AktifMi
                    };
                    return new Result(true, "Giriş Başarılı", isletmeDto);

                case Statu.Egitmen:
                    var egitmenDto = new EgitmenDto
                    {
                        KullaniciId = kullanici.KullaniciId,
                        Ad = kullanici.Ad,
                        Soyad = kullanici.Soyad,
                        TelefonNo = kullanici.TelefonNo,
                        DogumTarihi = kullanici.DogumTarihi,
                        IsletmeId = kullanici.IsletmeId,
                        AktifMi = kullanici.AktifMi
                    };
                    return new Result(true, "Giriş Başarılı", egitmenDto);

                case Statu.Uye:
                    var uyeDto = new UyeDto
                    {
                        KullaniciId = kullanici.KullaniciId,
                        Ad = kullanici.Ad,
                        Soyad = kullanici.Soyad,
                        TelefonNo = kullanici.TelefonNo,
                        KalanDersSayisi = kullanici.KalanDersSayisi,
                        DogumTarihi = kullanici.DogumTarihi,
                        IsletmeId = kullanici.IsletmeId,
                        EgitmenId = kullanici.EgitmenId,
                        AktifMi = kullanici.AktifMi
                    };
                    return new Result(true, "Giriş Başarılı", uyeDto);

                default:
                    return new Result(false, "Geçersiz Kullanıcı Statüsü");
            }
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }
}
