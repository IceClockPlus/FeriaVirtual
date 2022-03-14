using FeriaVirtual.API.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FeriaVirtual.API.Helpers;
using FeriaVirtual.API.Services;
using FeriaVirtual.API.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using FeriaVirtual.API.Models.Users;

namespace FeriaVirtual.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<JwtSettings> jwtSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            try
            {
                var response = _userService.Authenticate(model);
                return Ok(response);
            }
            catch (AppException appEx)
            {
                return BadRequest(appEx.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            _userService.Register(model);
            return Ok(new { message = "Registration successful" });
        }

    }
}
