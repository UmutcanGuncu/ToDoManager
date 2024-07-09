using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoManager.Application.Dtos.AuthDtos;
using ToDoManager.Domain.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoManager.WebAPI.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var value = await _userManager.CreateAsync(new AppUser()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                PhoneNumber = registerDto.Phone
            }, registerDto.Password);
            if (value.Succeeded)
            {
                return Ok();
            }
            return Unauthorized();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if(user == null)
            {
                return Unauthorized();
            }
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Unauthorized();
        }
    }
}

