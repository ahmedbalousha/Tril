using AutoMapper;
using BookStore.API.DTOs;
using BookStore.API.Models;
using BookStore.API.Services.Auth;
using BookStore.API.ViewModels;
using BookStore.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtToken;


        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;


        public AuthenticationController(IJwtTokenGenerator jwtToken, UserManager<AppUser> userManager,
            IMapper mapper)
        { 
            _jwtToken = jwtToken;
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestDto login)
        {
            var user = await _userManager.FindByNameAsync(login.username);
            var token = "";
            if (user != null && await _userManager.CheckPasswordAsync(user, login.password))
            {
                token = _jwtToken.Generate(user);
            }
            else
                throw new UnauthorizedAccessException();

            return Ok(new { token = token });
        }



        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequestDto registerRequestDto)
        {
          
            var userExists = await _userManager.FindByNameAsync(registerRequestDto.Email);
            if (userExists != null)
            {
                return BadRequest("User exists!");
            }
            var identityUser = _mapper.Map<AppUser>(registerRequestDto);
            identityUser.SecurityStamp = Guid.NewGuid().ToString();
            identityUser.UserName = registerRequestDto.Email;
            var result = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest("Error");
            }

            var token = _jwtToken.Generate(identityUser);

            return Ok(new RegisterResponseViewModel { Email = identityUser.Email, token = token, Username = identityUser.UserName });
        }
            

    }
}
