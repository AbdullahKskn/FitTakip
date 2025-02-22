using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTakip.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class IsletmeController : ControllerBase
    {
        private readonly IIsletmeService _ısletmeService;

        public IsletmeController(IIsletmeService ısletmeService)
        {
            _ısletmeService = ısletmeService;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> EgitmenOlustur(EgitmenOlusturParametre parameter)
        {
            var values = await _ısletmeService.EgitmenOlustur(parameter);
            return Ok(values);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> EgitmenGuncelle(EgitmenGuncelleParametre parameter)
        {
            var values = await _ısletmeService.EgitmenGuncelle(parameter);
            return Ok(values);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> EgitmenSil(int EgitmenId)
        {
            var values = await _ısletmeService.EgitmenSil(EgitmenId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> TumEgitmenleriGetir(int IsletmeId)
        {
            var values = await _ısletmeService.TumEgitmenleriGetir(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> TumUyeleriGetir(int IsletmeId)
        {
            var values = await _ısletmeService.TumUyeleriGetir(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> EgitmenleriGetirPagination(int IsletmeId, int Baslangic, int Adet)
        {
            var values = await _ısletmeService.EgitmenleriGetirPagination(IsletmeId, Baslangic, Adet);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> UyeleriGetirPagination(int IsletmeId, int Baslangic, int Adet)
        {
            var values = await _ısletmeService.UyeleriGetirPagination(IsletmeId, Baslangic, Adet);
            return Ok(values);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> GelirOlustur(GelirOlusturParametre parametre)
        {
            var values = await _ısletmeService.GelirOlustur(parametre);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> TumGelirlerToplami(int IsletmeId)
        {
            var values = await _ısletmeService.TumGelirlerToplami(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GelirleriTariheGöreGetirPagination(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet)
        {
            var values = await _ısletmeService.GelirleriTariheGöreGetirPagination(IsletmeId, BaslangicTarihi, BitisTarihi, Baslangic, Adet);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GelirleriTariheGöreTopla(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi)
        {
            var values = await _ısletmeService.GelirleriTariheGöreTopla(IsletmeId, BaslangicTarihi, BitisTarihi);
            return Ok(values);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> GiderOlustur(GiderOlusturParametre parametre)
        {
            var values = await _ısletmeService.GiderOlustur(parametre);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> TumGiderlerToplami(int IsletmeId)
        {
            var values = await _ısletmeService.TumGiderlerToplami(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GiderleriTariheGöreGetirPagination(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi, int Baslangic, int Adet)
        {
            var values = await _ısletmeService.GiderleriTariheGöreGetirPagination(IsletmeId, BaslangicTarihi, BitisTarihi, Baslangic, Adet);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GiderleriTariheGöreTopla(int IsletmeId, DateTime BaslangicTarihi, DateTime BitisTarihi)
        {
            var values = await _ısletmeService.GiderleriTariheGöreTopla(IsletmeId, BaslangicTarihi, BitisTarihi);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> TumGelirGiderToplami(int IsletmeId)
        {
            var values = await _ısletmeService.TumGelirGiderToplami(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> PotansiyelMusterileriGetirPagination(int IsletmeId, int Baslangic, int Adet)
        {
            var values = await _ısletmeService.PotansiyelMusterileriGetirPagination(IsletmeId, Baslangic, Adet);
            return Ok(values);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> PaketEkle(PaketEkleParametre parametre)
        {
            var values = await _ısletmeService.PaketEkle(parametre);
            return Ok(values);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> PaketSil(int PaketId)
        {
            var values = await _ısletmeService.PaketSil(PaketId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> PaketleriGetir(int IsletmeId)
        {
            var values = await _ısletmeService.PaketleriGetir(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> EgitmenTariheGöreDersSayisiGetir(int EgitmenId, DateTime BaslangicTarih, DateTime BitisTarih)
        {
            var values = await _ısletmeService.EgitmenTariheGöreDersSayisiGetir(EgitmenId, BaslangicTarih, BitisTarih);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> EgitmenMaasHesapla(int EgitmenId, DateTime BaslangicTarih, DateTime BitisTarih, int KomisyonOrani)
        {
            var values = await _ısletmeService.EgitmenMaasHesapla(EgitmenId, BaslangicTarih, BitisTarih, KomisyonOrani);
            return Ok(values);
        }
    }
}
