using AutoMapper;
using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeFarm.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;


			var user = GetUserById(Guid.Parse("56f19243-eba7-470e-bace-4880d06742ec"));//new User
			//{
			//	Id = Guid.NewGuid().ToString(),
			//	UserName = "Ivan 228",
			//	FirstName = "Ivan",
			//	SecondName = "Bad",
			//	Birthday = DateTime.Now,
			//	Email = "ivan@gmail.com",
			//	Password = "123456",
			//	PasswordHash = "121313sasa"
			//};

			_unitOfWork.UserManager.CreateAsync(user);
			_unitOfWork.UserManager.AddToRoleAsync(user, "User");

			_unitOfWork.Save();
		}

		public void Delete(Guid id)
		{
			var user = GetUserById(id);
			if (user != null)
			{
				_unitOfWork.UserManager.DeleteAsync(user);
				_unitOfWork.Save();
			}
		}

		public UserDTO GetUser(Guid id)
		{
			var user = GetUserById(id);
			return _mapper.Map<UserDTO>(user);
		}

		public IEnumerable<UserDTO> GetUsers()
		{
			var users = _unitOfWork.UserManager.Users.ToList();
			return _mapper.Map<IEnumerable<UserDTO>>(users);
		}

		public void Insert(UserDTO userDto)
		{
			var user = _mapper.Map<User>(userDto);
			_unitOfWork.Users.Insert(user);
			_unitOfWork.Save();
		}

		public void Update(UserDTO userDto)
		{
			var user = _mapper.Map<User>(userDto);
			_unitOfWork.Users.Update(user);
			_unitOfWork.Save();
		}

		public UserDTO GetUser(string email, string password)
		{
			var user = _unitOfWork.Users
				.Find(u => u.Email == email && u.Password == password)
				.FirstOrDefault();
			return _mapper.Map<UserDTO>(user);
		}

		private User GetUserById(Guid id)
		{
			return _unitOfWork.UserManager.Users.FirstOrDefault(u => u.Id == id.ToString());
		}	
	}
}
