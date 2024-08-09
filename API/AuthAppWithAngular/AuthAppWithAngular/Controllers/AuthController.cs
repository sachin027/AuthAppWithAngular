using AuthAppWithAngular.Container;
using AuthAppWithAngular.Interface;
using AuthAppWithAngular.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthAppWithAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthInterface _authInterface;

        public AuthController(IAuthInterface authInterface)
        {
            _authInterface = authInterface;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            var userData = await _authInterface.UserRegistration(userRegister);
            return Ok(userData);
        }
    }
}
