using BeeFarm.DAL.EF;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BeeFarm.DAL.Repositories
{
	public class StatisticsRepository : IRepository<Statistics>
	{
		private readonly BeeFarmContext _beeFarmContext;

		public StatisticsRepository(BeeFarmContext beeFarmContext)
		{
			_beeFarmContext = beeFarmContext;
		}

		public void Delete(int id)
		{
			var statistics = _beeFarmContext.Statistics.Find(id);
			if (statistics != null)
			{
				_beeFarmContext.Statistics.Remove(statistics);
			}
		}

		public IEnumerable<Statistics> Find(Func<Statistics, bool> predicate)
		{
			return _beeFarmContext.Statistics.Where(predicate);
		}

		public Statistics Get(int id)
		{
			return _beeFarmContext.Statistics.Find(id);
		}

		public IEnumerable<Statistics> GetAll()
		{
			return _beeFarmContext.Statistics;
		}

		public void Insert(Statistics item)
		{
			_beeFarmContext.Statistics.Add(item);
		}

		public void Update(Statistics item)
		{
			_beeFarmContext.Update(item);
		}
	}
}
