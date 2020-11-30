using BeeFarm.DAL.EF;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BeeFarm.DAL.Repositories
{
	public class UserRepository : IRepository<User>
	{
		private readonly BeeFarmContext _beeFarmContext;

		public UserRepository(BeeFarmContext beeFarmContext)
		{
			_beeFarmContext = beeFarmContext;
		}

		public void Delete(int id)
		{
			var user = _beeFarmContext.Users.Find(id);
			if (user != null)
			{
				_beeFarmContext.Entry(user)
					.Collection(u => u.BeeGardens)
					.Load();
				_beeFarmContext.Users.Remove(user);
			}
		}

		public IEnumerable<User> Find(Func<User, bool> predicate)
		{
			return _beeFarmContext.Users.Where(predicate);
		}

		public User Get(int id)
		{
			return _beeFarmContext.Users.Find(id);
		}

		public IEnumerable<User> GetAll()
		{
			return _beeFarmContext.Users;
		}

		public void Insert(User item)
		{
			_beeFarmContext.Users.Add(item);
		}

		public void Update(User item)
		{
			_beeFarmContext.Update(item);
		}
	}
}
