using eCommerce.SharedLibrary.DTOs.Account;
using eCommerce.Application.Services.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificationController(IIdentificationService identificationService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateAccount(CreateAccount account)
        {
            var result = await identificationService.CreateAccount(account);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAccount(LoginAccount account)
        {
            var result = await identificationService.LoginAccount(account);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
