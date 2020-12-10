using AutoMapper;
using BeeFarm.BLL.DTO;
using BeeFarm.BLL.BusinessModels;
using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BeeFarm.BLL.Services
{
	public class BeehiveService : IBeehiveService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IStatisticService _statisticService;

		public BeehiveService(IUnitOfWork unitOfWork, IMapper mapper, IStatisticService statisticService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_statisticService = statisticService;
		}

		public State GetBeehiveState(int beehiveId)
		{
			const int countOfValues = 5;
			var averageStatistic = _statisticService.GetAverageStatistic(beehiveId, countOfValues);
			var beehive = _unitOfWork.Beehives.Get(beehiveId);

			if (beehive != null)
			{
				var stateCalculator = new StateCalculator();
				return stateCalculator.GetState(averageStatistic, beehive);
			}

			return null;
		}

		public void Delete(int beehiveId)
		{
			_unitOfWork.Beehives.Delete(beehiveId);
			_unitOfWork.Save();
		}

		public BeehiveDTO GetBeehive(int beehiveId)
		{
			var beehive = _unitOfWork.Beehives.Get(beehiveId);
			return _mapper.Map<BeehiveDTO>(beehive);
		}

		public BeehiveDTO GetBeehive(int beehiveId, int beeGardenId)
		{
			var beehive = _unitOfWork.Beehives
				.Find(b => b.Id == beehiveId && b.BeeGardenId == beeGardenId)
				.FirstOrDefault();
			return _mapper.Map<BeehiveDTO>(beehive);
		}

		public IEnumerable<BeehiveDTO> GetBeehives()
		{
			var beehives = _unitOfWork.Beehives.GetAll();
			return _mapper.Map<IEnumerable<BeehiveDTO>>(beehives);
		}

		public IEnumerable<BeehiveDTO> GetBeehives(int beeGardenId)
		{
			var beehives = _unitOfWork.Beehives.Find(b => b.BeeGardenId == beeGardenId);
			return _mapper.Map<IEnumerable<BeehiveDTO>>(beehives);
		}

		public void Insert(BeehiveDTO beehiveDto)
		{
			var beehive = _mapper.Map<Beehive>(beehiveDto);
			_unitOfWork.Beehives.Insert(beehive);
			_unitOfWork.Save();
		}

		public void Update(BeehiveDTO beehiveDto)
		{
			var beehive = _mapper.Map<Beehive>(beehiveDto);
			_unitOfWork.Beehives.Update(beehive);
			_unitOfWork.Save();
		}
	}
}
