using MicroShop.IdentityServer.Dtos;
using MicroShop.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroShop.IdentityServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;

		public LoginController(SignInManager<ApplicationUser> signInManager)
        {
			_signInManager = signInManager;
		}

        [HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);
			if(result.Succeeded)
			{
				return Ok("Login Succes");
			}
			else
			{
				return Ok("Error ");
			}
		}
	}
}
