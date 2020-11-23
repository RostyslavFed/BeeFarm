using System.Collections.Generic;
using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeeFarm.Resource.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BeeGardenController : ControllerBase
	{
		private readonly IBeeGardenService _beeGardenService;

		public BeeGardenController(IBeeGardenService beeGardenService)
		{
			_beeGardenService = beeGardenService;
		}

		//GET: api/beegarden
		[HttpGet]
		public IEnumerable<BeeGardenDTO> Get()
		{
			return _beeGardenService.GetBeeGardens();
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
