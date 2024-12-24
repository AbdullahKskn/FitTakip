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
    }
}
