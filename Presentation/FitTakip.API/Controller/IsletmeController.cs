using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTakip.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IsletmeController : ControllerBase
    {
        private readonly IIsletmeService _isletmeService;

        public IsletmeController(IIsletmeService isletmeService)
        {
            _isletmeService = isletmeService;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> EgitmenOlustur(EgitmenOlusturParametre parameter)
        {
            var values = await _isletmeService.EgitmenOlustur(parameter);
            return Ok(values);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> EgitmenGuncelle(EgitmenGuncelleParametre parameter)
        {
            var values = await _isletmeService.EgitmenGuncelle(parameter);
            return Ok(values);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> EgitmenSil(long EgitmenId)
        {
            var values = await _isletmeService.EgitmenSil(EgitmenId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> TumEgitmenleriGetir(long IsletmeId)
        {
            var values = await _isletmeService.TumEgitmenleriGetir(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> TumUyeleriGetir(long IsletmeId)
        {
            var values = await _isletmeService.TumUyeleriGetir(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> EgitmenleriGetirPagination(long IsletmeId, int Baslangic, int Adet)
        {
            var values = await _isletmeService.EgitmenleriGetirPagination(IsletmeId, Baslangic, Adet);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> UyeleriGetirPagination(long IsletmeId, int Baslangic, int Adet)
        {
            var values = await _isletmeService.UyeleriGetirPagination(IsletmeId, Baslangic, Adet);
            return Ok(values);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> GelirOlustur(GelirOlusturParametre parametre)
        {
            var values = await _isletmeService.GelirOlustur(parametre);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> TumGelirlerToplami(long IsletmeId)
        {
            var values = await _isletmeService.TumGelirlerToplami(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GelirleriTariheGöreGetirPagination(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet)
        {
            var values = await _isletmeService.GelirleriTariheGöreGetirPagination(IsletmeId, BaslangicTarihi, BitisTarihi, Baslangic, Adet);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GelirleriTariheGöreTopla(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi)
        {
            var values = await _isletmeService.GelirleriTariheGöreTopla(IsletmeId, BaslangicTarihi, BitisTarihi);
            return Ok(values);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> GiderOlustur(GiderOlusturParametre parametre)
        {
            var values = await _isletmeService.GiderOlustur(parametre);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> TumGiderlerToplami(long IsletmeId)
        {
            var values = await _isletmeService.TumGiderlerToplami(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GiderleriTariheGöreGetirPagination(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet)
        {
            var values = await _isletmeService.GiderleriTariheGöreGetirPagination(IsletmeId, BaslangicTarihi, BitisTarihi, Baslangic, Adet);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GiderleriTariheGöreTopla(long IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi)
        {
            var values = await _isletmeService.GiderleriTariheGöreTopla(IsletmeId, BaslangicTarihi, BitisTarihi);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> TumGelirGiderToplami(long IsletmeId)
        {
            var values = await _isletmeService.TumGelirGiderToplami(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> PotansiyelMusterileriGetirPagination(long IsletmeId, int Baslangic, int Adet)
        {
            var values = await _isletmeService.PotansiyelMusterileriGetirPagination(IsletmeId, Baslangic, Adet);
            return Ok(values);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> PaketEkle(PaketEkleParametre parametre)
        {
            var values = await _isletmeService.PaketEkle(parametre);
            return Ok(values);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> PaketSil(long PaketId)
        {
            var values = await _isletmeService.PaketSil(PaketId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> PaketleriGetir(long IsletmeId)
        {
            var values = await _isletmeService.PaketleriGetir(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> EgitmenTariheGöreDersSayisiGetir(long EgitmenId, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            var values = await _isletmeService.EgitmenTariheGöreDersSayisiGetir(EgitmenId, BaslangicTarih, BitisTarih);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> EgitmenMaasHesapla(long EgitmenId, DateTime BaslangicTarih, DateTime BitisTarih, int KomisyonOrani)
        {
            var values = await _isletmeService.EgitmenMaasHesapla(EgitmenId, BaslangicTarih, BitisTarih, KomisyonOrani);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> UyeSorgulama(long IsletmeId, string? Ad, string? Soyad)
        {
            var values = await _isletmeService.UyeSorgulama(IsletmeId, Ad, Soyad);
            return Ok(values);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> SifreDegistir(SifreDegistirParametre parametre)
        {
            var values = await _isletmeService.SifreDegistir(parametre);
            return Ok(values);
        }
    }
}
