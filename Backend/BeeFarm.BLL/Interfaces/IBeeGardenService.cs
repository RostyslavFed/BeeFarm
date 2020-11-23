using BeeFarm.BLL.DTO;
using BeeFarm.DAL.Entity;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IBeeGardenService
	{
        void Insert(BeeGardenDTO beeGardenDto);
        void Update(BeeGardenDTO beeGardenDto);
        void Delete(int id);
        BeeGardenDTO GetBeeGarden(int id);
        IEnumerable<BeeGardenDTO> GetBeeGardens();
    }
}
