using BeeFarm.BLL.DTO;
using System;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IStatisticService
	{
		void Insert(StatisticDTO statisticDto);
		void Update(StatisticDTO statisticDto);
		void Delete(int StatisticId);
		StatisticDTO GetStatistic(int statisticId);
		StatisticDTO GetStatistic(int statisticId, int beehiveId);
		IEnumerable<StatisticDTO> GetStatistics();
		IEnumerable<StatisticDTO> GetStatistics(int beehiveId);
		IEnumerable<StatisticDTO> GetStatistics(int beehiveId, DateTime start, DateTime end);
	}
}
