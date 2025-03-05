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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> AdminOlustur(AdminOlusturParametre parameter)
        {
            var values = await _adminService.AdminOlustur(parameter);
            return Ok(values);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> AdminGuncelle(AdminGuncelleParametre parameter)
        {
            var values = await _adminService.AdminGuncelle(parameter);
            return Ok(values);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> AdminSil(long AdminId)
        {
            var values = await _adminService.AdminSil(AdminId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> AdminleriGetirPagination(int Baslangic, int Adet)
        {
            var values = await _adminService.AdminleriGetirPagination(Baslangic, Adet);
            return Ok(values);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> IsletmeOlustur(IsletmeOlusturParametre parameter)
        {
            var values = await _adminService.IsletmeOlustur(parameter);
            return Ok(values);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> IsletmeGuncelle(IsletmeGuncelleParametre parametre)
        {
            var values = await _adminService.IsletmeGuncelle(parametre);
            return Ok(values);
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> IsletmeSil(long IsletmeId)
        {
            var values = await _adminService.IsletmeSil(IsletmeId);
            return Ok(values);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> IsletmeyeKullanımSuresiEkle(IsletmeyeKullanımSuresiEkleParametre parametre)
        {
            var values = await _adminService.IsletmeyeKullanımSuresiEkle(parametre);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> IsletmeleriGetirPaginationAsync(int Baslangic, int Adet)
        {
            var values = await _adminService.IsletmeleriGetirPagination(Baslangic, Adet);
            return Ok(values);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> SifreDegistir(SifreDegistirParametre parametre)
        {
            var values = await _adminService.SifreDegistir(parametre);
            return Ok(values);
        }
    }
}
