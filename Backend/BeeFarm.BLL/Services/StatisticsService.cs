using AutoMapper;
using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System.Collections.Generic;

namespace BeeFarm.BLL.Services
{
	public class StatisticsService : IStatisticsService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public StatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public void Delete(int id)
		{
			_unitOfWork.Statistics.Delete(id);
			_unitOfWork.Save();
		}

		public IEnumerable<StatisticsDTO> GetStatistics()
		{
			var statistics = _unitOfWork.Statistics.GetAll();
			return _mapper.Map<IEnumerable<StatisticsDTO>>(statistics);
		}

		public StatisticsDTO GetStatistics(int id)
		{
			var statistics = _unitOfWork.Statistics.Get(id);
			return _mapper.Map<StatisticsDTO>(statistics);
		}

		public void Insert(StatisticsDTO statisticsDto)
		{
			var statistics = _mapper.Map<Statistics>(statisticsDto);
			_unitOfWork.Statistics.Insert(statistics);
			_unitOfWork.Save();
		}

		public void Update(StatisticsDTO statisticsDto)
		{
			var statistics = _mapper.Map<Statistics>(statisticsDto);
			_unitOfWork.Statistics.Update(statistics);
			_unitOfWork.Save();
		}
	}
}
