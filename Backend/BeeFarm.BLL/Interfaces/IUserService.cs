using BeeFarm.BLL.DTO;
using System;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IUserService
	{
		void Insert(UserDTO userDto);
		void Update(UserDTO userDto);
		void Delete(Guid id);
		UserDTO GetUser(Guid id);
		IEnumerable<UserDTO> GetUsers();
		UserDTO GetUser(string email, string password);
	}
}
