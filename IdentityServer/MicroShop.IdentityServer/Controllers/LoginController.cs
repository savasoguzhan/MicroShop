using MicroShop.IdentityServer.Dtos;
using MicroShop.IdentityServer.Models;
using MicroShop.IdentityServer.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace MicroShop.IdentityServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;

		public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
			_signInManager = signInManager;
			_userManager = userManager;
		}

        [HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);
			var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
			if(result.Succeeded)
			{
				GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
				model.Username = userLoginDto.UserName;
				model.Id = user.Id;
				var token = JwtTokenGenarator.GenerateToken(model);
				
				return Ok(token);
			}
			else
			{
				return Ok("Error ");
			}
		}
	}
}
