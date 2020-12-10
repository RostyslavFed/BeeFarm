using BeeFarm.BLL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BeeFarm.BLL.BusinessModels
{
	public class AverageStatistic
	{
		public double AverageTemperature { get; }

		public int AverageHumidity { get; }

		public double AverageWeight { get; }

		public AverageStatistic(IEnumerable<StatisticDTO> statistics)
		{
			foreach (var s in statistics)
			{
				AverageTemperature += s.Temperature;
				AverageHumidity += s.Humidity;
				AverageWeight += s.Weight;
			}

			var countOfElements = statistics.Count();
			if (countOfElements != 0)
			{
				AverageTemperature /= countOfElements;
				AverageHumidity /= countOfElements;
				AverageWeight /= countOfElements;
			}
		}
	}
}
