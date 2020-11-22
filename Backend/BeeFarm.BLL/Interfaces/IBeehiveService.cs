using BeeFarm.DAL.Entity;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IBeehiveService
	{
		void Insert(Beehive beehive);
		void Update(Beehive beehive);
		void Delete(int id);
		Beehive GetBeehive(int id);
		IEnumerable<Beehive> GetBeehives();
	}
}
