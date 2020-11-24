using System;

namespace BeeFarm.BLL.DTO
{
	public class UserDTO
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public DateTime Birthday { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string[] Roles { get; set; }
	}
}
