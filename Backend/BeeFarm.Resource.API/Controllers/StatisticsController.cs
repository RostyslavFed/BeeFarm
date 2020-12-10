using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BeeFarm.Resource.API.Controllers
{
	[Authorize(Roles = "admin, user")]
	[Route("api/statistics")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		private readonly IStatisticService _statisticsService;

		public StatisticsController(IStatisticService statisticsService)
		{
			_statisticsService = statisticsService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var statistics = _statisticsService.GetStatistics();
			if (statistics.Count() > 0)
			{
				return Ok(statistics);
			}
			return NoContent();
		}

		[HttpGet("{statisticId}")]
		public IActionResult GetById(int statisticId)
		{
			var statistic = _statisticsService.GetStatistic(statisticId);
			if (statistic != null)
			{
				return Ok(statistic);
			}
			return NoContent();
		}

		[HttpGet("interval/{beehiveId}/{start:datetime}/{end:datetime}")]
		public IActionResult GetByIdAndInterval(int beehiveId, DateTime start, DateTime end)
		{
			var statistics = _statisticsService.GetStatistics(beehiveId, start, end);
			if (statistics.Count() > 0)
			{
				return Ok(statistics);
			}
			return NoContent();
		}



		[HttpPost]
		public void Post([FromBody] StatisticDTO statistics)
		{
			_statisticsService.Insert(statistics);
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] StatisticDTO statistics)
		{
			statistics.Id = id;
			_statisticsService.Update(statistics);
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_statisticsService.Delete(id);
		}
	}
}
