using System;

namespace BeeFarm.BLL.DTO
{
	public class StatisticDTO
	{
		public int Id { get; set; }

		public DateTime DateTime { get; set; }

		public double Temperature { get; set; }

		public int Humidity { get; set; }

		public double Weight { get; set; }

		public string Location { get; set; }
	}
}
