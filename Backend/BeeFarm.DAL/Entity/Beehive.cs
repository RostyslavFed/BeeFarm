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

		public string Name { get; set; }

		public string Type { get; set; }

		public int NumberOfTheFrames { get; set; }

		public int YearOfTheQueenBee { get; set; }

		public string Description { get; set; }


		public int? BeeGardenId { get; set; }

		public virtual BeeGarden BeeGarden { get; set; }

		public virtual ICollection<Statistics> Statistics { get; set; }

	}
}
