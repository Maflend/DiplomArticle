
using AuthenticationBlazor.Server.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthenticationBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServerResponse<User>>> Register(UserRegister request)
        {
            try
            {
                var serviceResponse = await _authService.Register(request);
                return Ok(new ServerResponse<User> { Data = serviceResponse, Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse<User> { Message = ex.Message, Success = false });
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<ServerResponse<string>>> Login(UserLogin request)
        {
            try
            {
                var serviceResponse =  await _authService.Login(request);
                return Ok(new ServerResponse<string> {Data = serviceResponse, Success = true});
            }
            catch(Exception ex)
            {
                return BadRequest(new ServerResponse<string> { Message = ex.Message, Success = false});
            }
           
        }
    }
   
}
