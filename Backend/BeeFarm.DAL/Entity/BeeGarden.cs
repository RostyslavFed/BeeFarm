using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeeFarm.DAL.Entity
{
	public class BeeGarden
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public Guid? UserId { get; set; }

		public virtual User User { get; set; }

		public virtual ICollection<Beehive> Beehives { get; set; }

	}
}
