using FitTakip.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTakip.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UyeController : ControllerBase
    {
        private readonly IUyeService _uyeService;

        public UyeController(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> RandevulariGetirPagination(int UyeId, DateTime BaslangicTarih, DateTime BitisTarih, int Baslangic, int Adet)
        {
            var values = await _uyeService.RandevulariGetirPagination(UyeId, BaslangicTarih, BitisTarih, Baslangic, Adet);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> OlcumleriGetirPagination(int UyeId, int Baslangic, int Adet)
        {
            var values = await _uyeService.OlcumleriGetirPagination(UyeId, Baslangic, Adet);
            return Ok(values);
        }
    }
}
