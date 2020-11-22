using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeeFarm.BLL.Services;
using BeeFarm.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeeFarm.Resource.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BeeGardenController : ControllerBase
	{
		private readonly BeeGardenService _beeGardenService;

		public BeeGardenController(BeeGardenService beeGardenService)
		{
			_beeGardenService = beeGardenService;
		}

		// GET: api/<BeeGarden>
		[HttpGet]
		public IEnumerable<BeeGarden> Get()
		{
			return _beeGardenService.GetBeeGardens();
		}

		// GET api/<BeeGarden>/5
		[HttpGet("{id}")]
		public BeeGarden Get(int id)
		{
			return _beeGardenService.GetBeeGarden(id);
		}





		//// POST api/<ValuesController>
		//[HttpPost]
		//public void Post([FromBody] string value)
		//{
		//}

		//// PUT api/<ValuesController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/<ValuesController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
