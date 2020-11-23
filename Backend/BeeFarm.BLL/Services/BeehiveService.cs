using AutoMapper;
using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System.Collections.Generic;

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

		public void Delete(int id)
		{
			_unitOfWork.Beehives.Delete(id);
			_unitOfWork.Save();
		}

		public BeehiveDTO GetBeehive(int id)
		{
			var beehive = _unitOfWork.Beehives.Get(id);
			return _mapper.Map<BeehiveDTO>(beehive);
		}

		public IEnumerable<BeehiveDTO> GetBeehives()
		{
			var beehives = _unitOfWork.Beehives.GetAll();
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
