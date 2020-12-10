using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BeeFarm.Auth.API.Models;
using BeeFarm.Auth.Common;
using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BeeFarm.Auth.API.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IOptions<AuthOptions> _authOptions;
		private readonly IUserService _userService;

		public AuthController(IOptions<AuthOptions> authOptions, IUserService userService)
		{
			_authOptions = authOptions;
			_userService = userService;
		}

		[Route("login")]
		[HttpPost]
		public IActionResult Login([FromBody] Login request)
		{
			var user = _userService.GetUser(request.Email, request.Password);
			
			if (user != null)
			{
				var token = GenerateJWT(user);

				return Ok(new
				{
					access_token = token
				});
			}

			return Unauthorized();
		}

		private string GenerateJWT(UserDTO user)
		{
			var authParams = _authOptions.Value;

			var securityKey = authParams.GetSymmetricSecurityKey();
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
			};

			claims.Add(new Claim("role", user.Role));

			var token = new JwtSecurityToken(authParams.Issuer,
				authParams.Audience,
				claims,
				expires: DateTime.Now.AddSeconds(authParams.Tokenlifetime),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
