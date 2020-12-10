using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BeeFarm.Resource.API.Controllers
{
	[Authorize(Roles = "admin, user")]
	[Route("api/users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IBeeGardenService _beeGardenService;

		public UsersController(IUserService userService, IBeeGardenService beeGardenService)
		{
			_userService = userService;
			_beeGardenService = beeGardenService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var users = _userService.GetUsers();
			if (users.Count() > 0)
			{
				return Ok(users);
			}
			return NoContent();
		}

		[HttpGet("{userId}")]
		public IActionResult GetById(int userId)
		{
			var user = _userService.GetUser(userId);
			if (user != null)
			{
				return Ok(user);
			}
			return NoContent();
		}

		[HttpGet("{userId}/beegardens")]
		public IActionResult GetBeeGardens(int userId)
		{
			var beeGardens = _beeGardenService.GetBeeGardensByUserId(userId);
			if (beeGardens.Count() > 0)
			{
				return Ok(beeGardens);
			}
			return NoContent();
		}

		[HttpGet("{userId}/beegardens/{beeGardenId}")]
		public IActionResult GetBeeGarden(int userId, int beeGardenId)
		{
			var beeGarden = _beeGardenService.GetBeeGarden(beeGardenId, userId);
			if (beeGarden != null)
			{
				return Ok(beeGarden);
			}
			return NoContent();
		}

		[HttpPost]
		public IActionResult Post([FromBody] UserDTO user)
		{
			try
			{
				_userService.Insert(user);
			}
			catch(Exception e)
			{
				return BadRequest(e.Message);
			}
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] UserDTO user)
		{
			try
			{
				user.Id = id;
				_userService.Update(user);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
			return Ok();
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_userService.Delete(id);
		}
	}
}
