﻿
namespace BeeFarm.BLL.DTO
{
	public class BeehiveDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public int NumberOfTheFrames { get; set; }

		public int YearOfTheQueenBee { get; set; }

		public string Description { get; set; }

		public double RecommendedTemperature { get; set; }

		public int RecommendedHumidity { get; set; }

		public string DeviceId { get; set; }
	}
}
