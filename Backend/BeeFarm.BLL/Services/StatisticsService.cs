using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System.Collections.Generic;

namespace BeeFarm.BLL.Services
{
	public class StatisticsService : IStatisticsService
	{
		private readonly IUnitOfWork _unitOfWork;

		public StatisticsService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void Delete(int id)
		{
			_unitOfWork.Statistics.Delete(id);
			_unitOfWork.Save();
		}

		public IEnumerable<Statistics> GetBeeStatistics()
		{
			return _unitOfWork.Statistics.GetAll();
		}

		public Statistics GetStatistics(int id)
		{
			return _unitOfWork.Statistics.Get(id);
		}

		public void Insert(Statistics statistics)
		{
			_unitOfWork.Statistics.Insert(statistics);
			_unitOfWork.Save();
		}

		public void Update(Statistics statistics)
		{
			_unitOfWork.Statistics.Update(statistics);
			_unitOfWork.Save();
		}
	}
}
