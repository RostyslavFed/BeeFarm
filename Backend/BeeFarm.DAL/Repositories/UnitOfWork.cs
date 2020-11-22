using BeeFarm.DAL.EF;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeeFarm.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly BeeFarmContext _beeFarmContext;
		private BeeGardenRepository _beeGardenRepository;
		private BeehiveRepository _beehiveRepository;
		private StatisticsRepository _statisticsRepository;
		private UserRepository _userRepository;

		public IRepository<BeeGarden> BeeGardens
		{
			get
			{
				if (_beeGardenRepository is null)
				{
					_beeGardenRepository = new BeeGardenRepository(_beeFarmContext);
				}
				return _beeGardenRepository;
			}
		}

		public IRepository<Beehive> Beehives
		{
			get
			{
				if (_beehiveRepository is null)
				{
					_beehiveRepository = new BeehiveRepository(_beeFarmContext);
				}
				return _beehiveRepository;
			}
		}

		public IRepository<Statistics> Statistics
		{
			get
			{
				if (_statisticsRepository is null)
				{
					_statisticsRepository = new StatisticsRepository(_beeFarmContext);
				}
				return _statisticsRepository;
			}
		}

		public IRepository<User> Users
		{
			get
			{
				if (_userRepository is null)
				{
					_userRepository = new UserRepository(_beeFarmContext);
				}
				return _userRepository;
			}
		}

		public UnitOfWork()
		{
			var options = new DbContextOptions<BeeFarmContext>();
			_beeFarmContext = new BeeFarmContext(options);
		}

		public void Save()
		{
			_beeFarmContext.SaveChanges();
		}
	}
}
