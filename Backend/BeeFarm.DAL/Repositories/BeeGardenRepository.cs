using BeeFarm.DAL.EF;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeFarm.DAL.Repositories
{
	public class BeeGardenRepository : IRepository<BeeGarden>
	{
		private readonly BeeFarmContext _beeFarmContext;

		public BeeGardenRepository(BeeFarmContext beeFarmContext)
		{
			_beeFarmContext = beeFarmContext;
		}

		public void Insert(BeeGarden item)
		{
			_beeFarmContext.BeeGardens.Add(item);
		}

		public void Delete(int id)
		{
			var beeGarden = _beeFarmContext.BeeGardens.Find(id);
			if (beeGarden != null)
			{
				_beeFarmContext.Entry(beeGarden)
					.Collection(u => u.Beehives)
					.Load();
				_beeFarmContext.BeeGardens.Remove(beeGarden);
			}
		}

		public IEnumerable<BeeGarden> Find(Func<BeeGarden, bool> predicate)
		{
			return _beeFarmContext.BeeGardens.Where(predicate);
		}

		public BeeGarden Get(int id)
		{
			return _beeFarmContext.BeeGardens.Find(id);
		}

		public IEnumerable<BeeGarden> GetAll()
		{
			return _beeFarmContext.BeeGardens;
		}

		public void Update(BeeGarden item)
		{
			_beeFarmContext.Update(item);
		}
	}
}
