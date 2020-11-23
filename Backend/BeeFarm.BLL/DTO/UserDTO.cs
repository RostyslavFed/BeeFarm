using System;

namespace BeeFarm.BLL.DTO
{
	public class UserDTO
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public DateTime Birthday { get; set; }

		public string EmailAddress { get; set; }

		public string Password { get; set; }

		//Roles ???
	}
}
