using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeFarm.DAL.Entity
{
	public class User
	{
		[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "Field must be set")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Field must be set")]
		public string SecondName { get; set; }

		[Required(ErrorMessage = "Field must be set")]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		public string Role { get; set; }

		public virtual ICollection<BeeGarden> BeeGardens { get; set; }
	}
}
