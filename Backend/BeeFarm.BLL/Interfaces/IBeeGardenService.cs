using BeeFarm.DAL.Entity;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IBeeGardenService
	{
        void Insert(BeeGarden beeGarden);
        void Update(BeeGarden beeGarden);
        void Delete(int id);
        BeeGarden GetBeeGarden(int id);
        IEnumerable<BeeGarden> GetBeeGardens();
    }
}
