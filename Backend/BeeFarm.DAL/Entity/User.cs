using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeeFarm.DAL.Entity
{
	public class User
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Field must be set")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Field must be set")]
		public string SecondName { get; set; }

		[Required(ErrorMessage = "Field must be set")]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }

		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		public Role[] Roles { get; set; }

		public virtual ICollection<BeeGarden> BeeGardens { get; set; }

	}

	public enum Role
	{
		User,
		Admin
	}
}
