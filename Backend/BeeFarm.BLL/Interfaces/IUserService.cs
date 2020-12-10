using BeeFarm.BLL.DTO;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IUserService
	{
		void Insert(UserDTO userDto);
		void Update(UserDTO userDto);
		void Delete(int userId);
		UserDTO GetUser(int userId);
		IEnumerable<UserDTO> GetUsers();
		UserDTO GetUser(string email, string password);
	}
}
