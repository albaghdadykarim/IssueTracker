using AuthGateway.DTOs;
using Azure.Core;
using EntityFramework.Data.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthGateway
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase // Fix: Inherit from ControllerBase to access Unauthorized()
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AuthController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDtO loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);
            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginData.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid credentials");

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.GenerateToken(user, roles);

            return Ok(new { token });
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO newUser)
        {
            var existingUser = await _userManager.FindByEmailAsync(newUser.Email);
            if (existingUser != null)
            {
                return BadRequest("User already exists with this email.");
            }

            var user = new ApplicationUser
            {
                UserName = newUser.Email,
                Email = newUser.Email,
                FullName = newUser.FullName 
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            if (!string.IsNullOrEmpty(newUser.Role))
            {
                await _userManager.AddToRoleAsync(user, newUser.Role);
            }

            return Ok(new { message = "User created successfully" });

        }
    }
}
