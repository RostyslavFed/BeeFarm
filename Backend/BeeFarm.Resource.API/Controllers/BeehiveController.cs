using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeeFarm.Resource.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BeehiveController : ControllerBase
	{
		private readonly IBeehiveService _beehiveService;

		public BeehiveController(IBeehiveService beehiveService)
		{
			_beehiveService = beehiveService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_beehiveService.GetBeehives());
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_beehiveService.GetBeehive(id));
		}

		[HttpPost]
		public void Post([FromBody] BeehiveDTO beehive)
		{
			_beehiveService.Insert(beehive);
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] BeehiveDTO beehive)
		{
			beehive.Id = id;
			_beehiveService.Update(beehive);
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_beehiveService.Delete(id);
		}
	}
}
