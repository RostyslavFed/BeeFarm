using AutoMapper;
using BeeFarm.BLL.DTO;
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

		public BeehiveService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
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
