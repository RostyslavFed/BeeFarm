using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeeFarm.DAL.Entity
{
	public class User : IdentityUser
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string SecondName { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		public virtual ICollection<BeeGarden> BeeGardens { get; set; }
	}
}
