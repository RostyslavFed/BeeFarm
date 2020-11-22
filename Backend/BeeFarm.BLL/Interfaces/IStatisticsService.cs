using BeeFarm.DAL.Entity;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IStatisticsService
	{
		void Insert(Statistics statistics);
		void Update(Statistics statistics);
		void Delete(int id);
		Statistics GetStatistics(int id);
		IEnumerable<Statistics> GetBeeStatistics();
	}
}
