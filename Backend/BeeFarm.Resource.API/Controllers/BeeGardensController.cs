using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BeeFarm.Resource.API.Controllers
{
	[Authorize(Roles = "admin, user")]
	[Route("api/beegardens")]
	[ApiController]
	public class BeeGardensController : ControllerBase
	{
		private readonly IBeeGardenService _beeGardenService;
		private readonly IBeehiveService _beehiveService;

		public BeeGardensController(IBeeGardenService beeGardenService, IBeehiveService beehiveService)
		{
			_beeGardenService = beeGardenService;
			_beehiveService = beehiveService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var beeGardens = _beeGardenService.GetBeeGardens();
			if (beeGardens.Count() > 0)
			{
				return Ok(beeGardens);
			}
			return NoContent();
		}

		[HttpGet("{beeGardenId}")]
		public IActionResult GetById(int beeGardenId)
		{
			var beeGarden = _beeGardenService.GetBeeGarden(beeGardenId);
			if (beeGarden != null)
			{
				return Ok(beeGarden);
			}
			return NoContent();
		}

		[HttpGet("{beeGardenId}/beehives")]
		public IActionResult GetBeehives(int beeGardenId)
		{
			var beehives = _beehiveService.GetBeehives(beeGardenId);
			if (beehives.Count() > 0)
			{
				return Ok(beehives);
			}
			return NoContent();
		}

		[HttpGet("{beeGardenId}/beehives/{beehiveId}")]
		public IActionResult GetBeehive(int beeGardenId, int beehiveId)
		{
			var beehive = _beehiveService.GetBeehive(beehiveId, beeGardenId);
			if (beehive != null)
			{
				return Ok(beehive);
			}
			return NoContent();
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
		public void Delete(int id)
		{
			_beeGardenService.Delete(id);
		}
	}
}
