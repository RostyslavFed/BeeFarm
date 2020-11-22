using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System.Collections.Generic;

namespace BeeFarm.BLL.Services
{
	public class BeeGardenService : IBeeGardenService
	{
		private readonly IUnitOfWork _unitOfWork;

		public BeeGardenService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void Delete(int id)
		{
			_unitOfWork.BeeGardens.Delete(id);
			_unitOfWork.Save();
		}

		public BeeGarden GetBeeGarden(int id)
		{
			return _unitOfWork.BeeGardens.Get(id);
		}

		public IEnumerable<BeeGarden> GetBeeGardens()
		{
			return _unitOfWork.BeeGardens.GetAll();
		}

		public void Insert(BeeGarden beeGarden)
		{
			_unitOfWork.BeeGardens.Insert(beeGarden);
			_unitOfWork.Save();
		}

		public void Update(BeeGarden beeGarden)
		{
			_unitOfWork.BeeGardens.Update(beeGarden);
			_unitOfWork.Save();
		}
	}
}
