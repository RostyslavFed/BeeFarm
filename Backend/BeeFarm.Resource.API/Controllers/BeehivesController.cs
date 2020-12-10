using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BeeFarm.Resource.API.Controllers
{
	[Authorize(Roles = "admin, user")]
	[Route("api/beehives")]
	[ApiController]
	public class BeehivesController : ControllerBase
	{
		private readonly IBeehiveService _beehiveService;
		private readonly IStatisticService _statisticService;

		public BeehivesController(IBeehiveService beehiveService, IStatisticService statisticService)
		{
			_beehiveService = beehiveService;
			_statisticService = statisticService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var beehives = _beehiveService.GetBeehives();
			if (beehives.Count() > 0)
			{
				return Ok(beehives);
			}
			return NoContent();
		}

		[HttpGet("{beehiveId}")]
		public IActionResult GetById(int beehiveId)
		{
			var beehive = _beehiveService.GetBeehive(beehiveId);
			if (beehive != null)
			{
				return Ok(beehive);
			}
			return NoContent();
		}

		[HttpGet("{beehiveId}/state")]
		public IActionResult GetState(int beehiveId)
		{
			var state = _beehiveService.GetBeehiveState(beehiveId);
			if (state != null)
			{
				return Ok(state);
			}
			return NoContent();
		}

		[HttpGet("{beehiveId}/statistics")]
		public IActionResult GetStatistics(int beehiveId)
		{
			var statistics = _statisticService.GetStatistics(beehiveId);
			if (statistics.Count() > 0)
			{
				return Ok(statistics);
			}
			return NoContent();
		}

		[HttpGet("{beehiveId}/statistics/{statisticId}")]
		public IActionResult GetStatistic(int beehiveId, int statisticId)
		{
			var statistic = _statisticService.GetStatistic(statisticId, beehiveId);
			if (statistic != null)
			{
				return Ok(statistic);
			}
			return NoContent();
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
