using System.ComponentModel.DataAnnotations;

namespace BeeFarm.DAL.Entity
{
	public class Statistics
	{
		[Key]
		public int Id { get; set; }

		public double Temperature { get; set; }

		public int MoisturePercentage { get; set; }

		public double Weight { get; set; }

		public string Location { get; set; }


		public int? BeehiveId { get; set; }

		public virtual Beehive Beehive { get; set; }

	}
}
