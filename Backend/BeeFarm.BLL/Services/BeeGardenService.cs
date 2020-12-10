using AutoMapper;
using BeeFarm.BLL.DTO;
using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BeeFarm.BLL.Services
{
	public class BeeGardenService : IBeeGardenService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public BeeGardenService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public void Delete(int beeGardenId)
		{
			_unitOfWork.BeeGardens.Delete(beeGardenId);
			_unitOfWork.Save();
		}

		public BeeGardenDTO GetBeeGarden(int beeGardenId)
		{
			var beeGarden = _unitOfWork.BeeGardens.Get(beeGardenId);
			return _mapper.Map<BeeGardenDTO>(beeGarden);
		}

		public IEnumerable<BeeGardenDTO> GetBeeGardens()
		{
			var beeGardens = _unitOfWork.BeeGardens.GetAll();
			return _mapper.Map<IEnumerable<BeeGardenDTO>>(beeGardens);
		}

		public void Insert(BeeGardenDTO beeGardenDto)
		{
			var beeGarden = _mapper.Map<BeeGarden>(beeGardenDto);
			_unitOfWork.BeeGardens.Insert(beeGarden);
			_unitOfWork.Save();
		}

		public void Update(BeeGardenDTO beeGardenDto)
		{
			var beeGarden = _mapper.Map<BeeGarden>(beeGardenDto);
			_unitOfWork.BeeGardens.Update(beeGarden);
			_unitOfWork.Save();
		}

		public IEnumerable<BeeGardenDTO> GetBeeGardensByUserId(int userId)
		{
			var beeGardens = _unitOfWork.BeeGardens.Find(b => b.UserId == userId);
			return _mapper.Map<IEnumerable<BeeGardenDTO>>(beeGardens);
		}

		public BeeGardenDTO GetBeeGarden(int beeGardenId, int userId)
		{
			var beeGarden = _unitOfWork.BeeGardens
				.Find(b => b.Id == beeGardenId && b.UserId == userId)
				.FirstOrDefault();
			return _mapper.Map<BeeGardenDTO>(beeGarden);
		}
	}
}
