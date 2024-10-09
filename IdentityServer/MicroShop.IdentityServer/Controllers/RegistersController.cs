﻿using MicroShop.IdentityServer.Dtos;
using MicroShop.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                Email = userRegisterDto.Email,
                UserName = userRegisterDto.Username,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname
            };
            var result = await _userManager.CreateAsync(values,userRegisterDto.Password);
            if(result.Succeeded)
            {
                return Ok("User added");
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
