using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeFarm.DAL.Entity
{
	public class BeeGarden
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int? UserId { get; set; }

		public virtual User User { get; set; }

		public virtual ICollection<Beehive> Beehives { get; set; }

	}
}
