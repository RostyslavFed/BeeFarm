using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeeFarm.Resource.API.Controllers
{
	[Authorize(Roles = "admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_userService.GetUsers());
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_userService.GetUser(id));
		}

		[HttpPost]
		public void Post([FromBody] UserDTO user)
		{
			_userService.Insert(user);
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] UserDTO user)
		{
			user.Id = id;
			_userService.Update(user);
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_userService.Delete(id);
		}
	}
}
