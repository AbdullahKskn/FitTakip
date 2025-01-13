using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTakip.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
