using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System.Collections.Generic;

namespace BeeFarm.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;

		public UserService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void Delete(int id)
		{
			_unitOfWork.Users.Delete(id);
			_unitOfWork.Save();
		}

		public User GetUser(int id)
		{
			return _unitOfWork.Users.Get(id);
		}

		public IEnumerable<User> GetUsers()
		{
			return _unitOfWork.Users.GetAll();
		}

		public void Insert(User user)
		{
			_unitOfWork.Users.Insert(user);
			_unitOfWork.Save();
		}

		public void Update(User user)
		{
			_unitOfWork.Users.Update(user);
			_unitOfWork.Save();
		}
	}
}
