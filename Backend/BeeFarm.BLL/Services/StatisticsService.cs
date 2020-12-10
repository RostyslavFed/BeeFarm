using AutoMapper;
using BeeFarm.BLL.BusinessModels;
using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeFarm.BLL.Services
{
	public class StatisticsService : IStatisticService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public StatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public void Delete(int beehiveId)
		{
			_unitOfWork.Statistics.Delete(beehiveId);
			_unitOfWork.Save();
		}

		public IEnumerable<StatisticDTO> GetStatistics()
		{
			var statistics = _unitOfWork.Statistics.GetAll();
			return _mapper.Map<IEnumerable<StatisticDTO>>(statistics);
		}

		public StatisticDTO GetStatistic(int statisticId)
		{
			var statistic = _unitOfWork.Statistics.Get(statisticId);
			return _mapper.Map<StatisticDTO>(statistic);
		}

		public void Insert(StatisticDTO statisticDto)
		{
			var statistic = _mapper.Map<Statistic>(statisticDto);
			_unitOfWork.Statistics.Insert(statistic);
			_unitOfWork.Save();
		}

		public void Update(StatisticDTO statisticDto)
		{
			var statistic = _mapper.Map<Statistic>(statisticDto);
			_unitOfWork.Statistics.Update(statistic);
			_unitOfWork.Save();
		}

		public StatisticDTO GetStatistic(int statisticId, int beehiveId)
		{
			var statistic = GetStatisticsByBeehiveId(beehiveId)
				.First(s => s.Id == statisticId);
			return _mapper.Map<StatisticDTO>(statistic);
		}

		public IEnumerable<StatisticDTO> GetStatistics(int beehiveId)
		{
			var statistics = GetStatisticsByBeehiveId(beehiveId);
			return _mapper.Map<IEnumerable<StatisticDTO>>(statistics);
		}

		public IEnumerable<StatisticDTO> GetStatistics(int beehiveId, DateTime start, DateTime end)
		{
			var statistics = GetStatisticsByBeehiveId(beehiveId)
				.Where(s => s.DateTime >= start && s.DateTime <= end);
			return _mapper.Map<IEnumerable<StatisticDTO>>(statistics);
		}

		public IEnumerable<StatisticDTO> GetLatestStatistics(int beehiveId, int count)
		{
			var statistics = GetStatisticsByBeehiveId(beehiveId)
				.OrderBy(s => s.DateTime)
				.Take(count);
			return _mapper.Map<IEnumerable<StatisticDTO>>(statistics);
		}

		public AverageStatistic GetAverageStatistic(int beehiveId, int count)
		{
			var statistics = GetLatestStatistics(beehiveId, count);
			var statisticDTOs = _mapper.Map<IEnumerable<StatisticDTO>>(statistics);
			return new AverageStatistic(statisticDTOs);
		}


		private IEnumerable<Statistic> GetStatisticsByBeehiveId(int beehiveId)
		{
			return _unitOfWork.Statistics.Find(s => s.BeehiveId == beehiveId);
		}
	}
}
