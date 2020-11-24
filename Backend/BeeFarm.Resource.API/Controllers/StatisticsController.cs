using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeeFarm.Resource.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		private readonly IStatisticsService _statisticsService;

		public StatisticsController(IStatisticsService statisticsService)
		{
			_statisticsService = statisticsService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_statisticsService.GetStatistics());
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_statisticsService.GetStatistics(id));
		}

		[HttpPost]
		public void Post([FromBody] StatisticsDTO statistics)
		{
			_statisticsService.Insert(statistics);
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] StatisticsDTO statistics)
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
