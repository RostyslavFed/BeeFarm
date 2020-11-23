using BeeFarm.BLL.DTO;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IStatisticsService
	{
		void Insert(StatisticsDTO statisticsDto);
		void Update(StatisticsDTO statisticsDto);
		void Delete(int id);
		StatisticsDTO GetStatistics(int id);
		IEnumerable<StatisticsDTO> GetStatistics();
	}
}
