using BeeFarm.DAL.EF;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BeeFarm.DAL.Repositories
{
	public class BeehiveRepository : IRepository<Beehive>
	{
		private readonly BeeFarmContext _beeFarmContext;

		public BeehiveRepository(BeeFarmContext beeFarmContext)
		{
			_beeFarmContext = beeFarmContext;
		}

		public void Insert(Beehive item)
		{
			_beeFarmContext.Beehives.Add(item);
		}

		public void Delete(int id)
		{
			var beehive = _beeFarmContext.Beehives.Find(id);
			if (beehive != null)
			{
				_beeFarmContext.Beehives.Remove(beehive);
			}
		}

		public IEnumerable<Beehive> Find(Func<Beehive, bool> predicate)
		{
			return _beeFarmContext.Beehives.Where(predicate);
		}

		public Beehive Get(int id)
		{
			return _beeFarmContext.Beehives.Find(id);
		}

		public IEnumerable<Beehive> GetAll()
		{
			return _beeFarmContext.Beehives;
		}

		public void Update(Beehive item)
		{
			_beeFarmContext.Entry(item).State = EntityState.Modified;
		}
	}
}
