﻿using AutoMapper;
using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using BeeFarm.BLL.Infrastructure;

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
		}

		public void Delete(int id)
		{
			_unitOfWork.Users.Delete(id);
			_unitOfWork.Save();
		}

		public UserDTO GetUser(int id)
		{
			var user = _unitOfWork.Users.Get(id);
			return _mapper.Map<UserDTO>(user);
		}

		public IEnumerable<UserDTO> GetUsers()
		{
			var users = _unitOfWork.Users.GetAll();
			return _mapper.Map<IEnumerable<UserDTO>>(users);
		}

		public void Insert(UserDTO userDto)
		{
			if (EmailTaken(userDto.Email))
			{
				throw new Exception("Email is already registered!");
			}

			var user = _mapper.Map<User>(userDto);
			user.Password = HashAlgorithm.CreateMD5(userDto.Password);
			_unitOfWork.Users.Insert(user);
			_unitOfWork.Save();
		}

		public void Update(UserDTO userDto)
		{
			var oldEmail = GetUser(userDto.Id).Email;
			if (oldEmail == userDto.Email || !EmailTaken(userDto.Email))
			{
				var user = _mapper.Map<User>(userDto);
				_unitOfWork.Users.Update(user);
				_unitOfWork.Save();
			}
			else
			{
				throw new Exception("Email is already taken!");
			}
		}

		public UserDTO GetUser(string email, string password)
		{
			var passwordHash = HashAlgorithm.CreateMD5(password);
			var user = _unitOfWork.Users
				.Find(u => u.Email == email && u.Password == passwordHash)
				.FirstOrDefault();
			return _mapper.Map<UserDTO>(user);
		}

		private bool EmailTaken(string email)
		{
			return _unitOfWork.Users.Find(u => u.Email == email).Count() > 0;
		}
	}
}
