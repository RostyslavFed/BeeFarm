using System;

namespace BeeFarm.BLL.DTO
{
	public class StatisticsDTO
	{
		public int Id { get; set; }

		public DateTime DataTime { get; set; }

		public double Temperature { get; set; }

		public int MoisturePercentage { get; set; }

		public double Weight { get; set; }

		public string Location { get; set; }

		public int? BeehiveId { get; set; }
	}
}
