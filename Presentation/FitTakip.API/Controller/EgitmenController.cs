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
    public class EgitmenController : ControllerBase
    {
        private readonly IEgitmenService _egitmenService;

        public EgitmenController(IEgitmenService egitmenService)
        {
            _egitmenService = egitmenService;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> UyeOlustur(UyeOlusturParametre parametre)
        {
            var values = await _egitmenService.UyeOlustur(parametre);
            return Ok(values);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> UyeGuncelle(UyeGuncelleParametre parametre)
        {
            var values = await _egitmenService.UyeGuncelle(parametre);
            return Ok(values);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> UyeSil(int UyeId)
        {
            var values = await _egitmenService.UyeSil(UyeId);
            return Ok(values);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> UyeyePaketEkle(UyeyePaketEkleParametre parametre)
        {
            var values = await _egitmenService.UyeyePaketEkle(parametre);
            return Ok(values);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> RandevuOlustur(RandevuOlusturParametre parametre)
        {
            var values = await _egitmenService.RandevuOlustur(parametre);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> UyeyeAitRandevularıGetirPagination(int UyeId, int Baslangic, int Adet)
        {
            var values = await _egitmenService.UyeyeAitRandevularıGetirPagination(UyeId, Baslangic, Adet);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GunlukRandevuGetir(int EgitmenId, DateTime Tarih)
        {
            var values = await _egitmenService.GunlukRandevuGetir(EgitmenId, Tarih);
            return Ok(values);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> OlcumOlustur(OlcumOlusturParametre parametre)
        {
            var values = await _egitmenService.OlcumOlustur(parametre);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> UyeOlcumGetirPagination(int UyeId, int Baslangic, int Adet)
        {
            var values = await _egitmenService.UyeOlcumGetirPagination(UyeId, Baslangic, Adet);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> PaketleriGetir(int IsletmeId)
        {
            var values = await _egitmenService.PaketleriGetir(IsletmeId);
            return Ok(values);
        }
    }
}
