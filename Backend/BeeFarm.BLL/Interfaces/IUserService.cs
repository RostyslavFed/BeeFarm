using BeeFarm.DAL.Entity;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IUserService
	{
		void Insert(User user);
		void Update(User user);
		void Delete(int id);
		User GetUser(int id);
		IEnumerable<User> GetUsers();
	}
}
