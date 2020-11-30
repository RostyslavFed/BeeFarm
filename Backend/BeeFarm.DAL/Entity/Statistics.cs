using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeFarm.DAL.Entity
{
	public class Statistics
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public DateTime DateTime { get; set; }

		public double Temperature { get; set; }

		public int MoisturePercentage { get; set; }

		public double Weight { get; set; }

		[StringLength(50)]
		public string Location { get; set; }


		public int? BeehiveId { get; set; }

		public virtual Beehive Beehive { get; set; }
	}
}
