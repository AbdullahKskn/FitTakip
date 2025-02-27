using System;
using FitTakip.Application.Common;
using FitTakip.Application.DTOs;
using FitTakip.Application.Interfaces.Repositories;
using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using FitTakip.Domain.Entities;

namespace FitTakip.Persistence.Service;

public class LoginService : ILoginService
{
    private readonly ILoginRepository _loginRepository;
    private readonly AuthService _authService;
    private readonly ITokenService _tokenService;
    private readonly IRepository<Admin> _repositoryAdmin;
    private readonly IRepository<Isletme> _repositoryIsletme;
    private readonly IRepository<Egitmen> _repositoryEgitmen;

    public LoginService(ILoginRepository loginRepository, AuthService authService, ITokenService tokenService, IRepository<Admin> repositoryAdmin, IRepository<Egitmen> repositoryEgitmen, IRepository<Isletme> repositoryIsletme)
    {
        _loginRepository = loginRepository;
        _authService = authService;
        _tokenService = tokenService;
        _repositoryAdmin = repositoryAdmin;
        _repositoryEgitmen = repositoryEgitmen;
        _repositoryIsletme = repositoryIsletme;
    }

    public async Task<Result> GirisYap(GirisYapParametre parametre)
    {
        try
        {
            var admin = await _loginRepository.AdminKullaniciAdınaGöreGetir(parametre.KullaniciAdi);
            var isletme = await _loginRepository.IsletmeKullaniciAdınaGöreGetir(parametre.KullaniciAdi);
            var egitmen = await _loginRepository.EgitmenKullaniciAdınaGöreGetir(parametre.KullaniciAdi);

            var kullanici = (object)admin ?? (object)isletme ?? (object)egitmen;

            if (kullanici == null)
                return new Result(false, "Böyle bir kullanıcı bulunamadı.");

            // Şifre doğrulama
            string sifreKarmasi = admin?.SifreKarmasi ?? isletme?.SifreKarmasi ?? egitmen?.SifreKarmasi;
            if (!_authService.VerifyPassword(parametre.Sifre, sifreKarmasi))
                return new Result(false, "Şifre yanlış.");

            if (admin?.AktifMi == false)
                return new Result(false, "Aktif üyeliğiniz bulunmamaktadır.");

            // Abonelik ve aktiflik kontrolleri
            if (isletme?.AbonelikSonlanmaTarihi < DateTime.Now)
                return new Result(false, "Abonelik tarihiniz sonlanmıştır.");

            if (isletme?.AktifMi == false)
                return new Result(false, "Aktif üyeliğiniz bulunmamaktadır.");

            if (egitmen != null)
            {
                if (egitmen.AktifMi == false)
                    return new Result(false, "Aktif üyeliğiniz bulunmamaktadır.");

                if (egitmen.Isletme?.AbonelikSonlanmaTarihi < DateTime.Now)
                    return new Result(false, "İşletmenize ait abonelik tarihiniz sonlanmıştır.");

                if (egitmen.Isletme?.AktifMi == false)
                    return new Result(false, "İşletmenizin Aktif Aboneliği Bulunmamaktadır.");
            }

            // Kullanıcı doğrulandı, token oluştur
            Token token = _tokenService.CreateAccessToken();

            object kullaniciDto = null;

            if (admin != null)
            {
                kullaniciDto = new AdminDto
                {
                    AdminId = admin.AdminId,
                    Ad = admin.Ad,
                    Soyad = admin.Soyad,
                    Rol = "Admin",
                    Token = token.AccessToken
                };
            }
            else if (isletme != null)
            {
                kullaniciDto = new IsletmeDto
                {
                    IsletmeId = isletme.IsletmeId,
                    Ad = isletme.Ad,
                    TelefonNo = isletme.TelefonNo,
                    AbonelikSonlanmaTarihi = isletme.AbonelikSonlanmaTarihi,
                    AktifMi = isletme.AktifMi,
                    Rol = "İşletme",
                    Token = token.AccessToken
                };
            }
            else if (egitmen != null)
            {
                kullaniciDto = new EgitmenDto
                {
                    EgitmenId = egitmen.EgitmenId,
                    Ad = egitmen.Ad,
                    Soyad = egitmen.Soyad,
                    TelefonNo = egitmen.TelefonNo,
                    IsletmeId = egitmen.IsletmeId,
                    AktifMi = egitmen.AktifMi,
                    Rol = "Eğitmen",
                    Token = token.AccessToken
                };
            }

            return new Result(true, "Giriş başarılı", kullaniciDto);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }
}
