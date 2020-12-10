using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeFarm.DAL.Entity
{
	public class Beehive
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[StringLength(50)]
		public string Name { get; set; }

		[StringLength(50)]
		public string Type { get; set; }

		public int NumberOfTheFrames { get; set; }

		public int YearOfTheQueenBee { get; set; }

		public string Description { get; set; }


		public int? BeeGardenId { get; set; }

		public virtual BeeGarden BeeGarden { get; set; }

		public virtual ICollection<Statistic> Statistics { get; set; }

	}
}
