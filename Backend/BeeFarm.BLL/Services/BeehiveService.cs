using BeeFarm.BLL.Interfaces;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Interfaces;
using System.Collections.Generic;

namespace BeeFarm.BLL.Services
{
	public class BeehiveService : IBeehiveService
	{
		private readonly IUnitOfWork _unitOfWork;

		public BeehiveService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void Delete(int id)
		{
			_unitOfWork.Beehives.Delete(id);
			_unitOfWork.Save();
		}

		public Beehive GetBeehive(int id)
		{
			return _unitOfWork.Beehives.Get(id);
		}

		public IEnumerable<Beehive> GetBeehives()
		{
			return _unitOfWork.Beehives.GetAll();
		}

		public void Insert(Beehive beehive)
		{
			_unitOfWork.Beehives.Insert(beehive);
			_unitOfWork.Save();
		}

		public void Update(Beehive beehive)
		{
			_unitOfWork.Beehives.Update(beehive);
			_unitOfWork.Save();
		}
	}
}
