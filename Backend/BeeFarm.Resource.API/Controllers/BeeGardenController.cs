using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeeFarm.Resource.API.Controllers
{
	//[Authorize(Roles = "admin, user")]
	[Route("api/[controller]")]
	[ApiController]
	public class BeeGardenController : ControllerBase
	{
		private readonly IBeeGardenService _beeGardenService;

		public BeeGardenController(IBeeGardenService beeGardenService)
		{
			_beeGardenService = beeGardenService;
		}

		//[Authorize (Roles = "admin, user")]
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_beeGardenService.GetBeeGardens());
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_beeGardenService.GetBeeGarden(id));
		}

		[HttpPost]
		public void Post([FromBody] BeeGardenDTO beeGarden)
		{
			_beeGardenService.Insert(beeGarden);
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] BeeGardenDTO beeGarden)
		{
			beeGarden.Id = id;
			_beeGardenService.Update(beeGarden);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_beeGardenService.Delete(id);
			return Ok();
		}
	}
}
