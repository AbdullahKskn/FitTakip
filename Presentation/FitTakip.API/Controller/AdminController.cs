using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTakip.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> AdminSil(int AdminId)
        {
            var values = await _adminService.AdminSil(AdminId);
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
        public async Task<IActionResult> IsletmeSil(int IsletmeId)
        {
            var values = await _adminService.IsletmeSil(IsletmeId);
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> IsletmeleriGetirPaginationAsync(int Baslangic, int Adet)
        {
            var values = await _adminService.IsletmeleriGetirPaginationAsync(Baslangic, Adet);
            return Ok(values);
        }
    }
}
