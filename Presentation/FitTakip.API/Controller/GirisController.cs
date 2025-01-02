using FitTakip.Application.Interfaces.Services;
using FitTakip.Application.Parametre;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTakip.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GirisController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public GirisController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> GirisYap(GirisYapParametre parameter)
        {
            var values = await _loginService.GirisYap(parameter);
            return Ok(values);
        }
    }
}
