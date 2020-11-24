﻿using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeeFarm.Resource.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BeeGardenController : ControllerBase
	{
		private readonly IBeeGardenService _beeGardenService;
		private readonly IUserService _userService;

		public BeeGardenController(IBeeGardenService beeGardenService, IUserService userService)
		{
			_beeGardenService = beeGardenService;
			_userService = userService;
		}

		//GET: api/beegarden
		[HttpGet]
		[Authorize (Roles = "admin,user")]
		public IActionResult Get()
		{
			return Ok(_userService.GetUsers());
		}

		// GET api/<beegarden/5
		[HttpGet("{id}")]
		public BeeGardenDTO Get(int id)
		{
			return _beeGardenService.GetBeeGarden(id);
		}

		// POST api/beegarden
		//[HttpPost]
		//public void Post([FromBody] string value)
		//{

		//}

		//// PUT api/beegarden/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{

		//}

		// DELETE api/beegarden/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_beeGardenService.Delete(id);
			return Ok();
		}
	}
}
