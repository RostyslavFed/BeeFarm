using System;

namespace BeeFarm.BLL.DTO
{
	public class UserDTO
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public DateTime Birthday { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }
	}
}
