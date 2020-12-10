using BeeFarm.BLL.DTO;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IBeeGardenService
	{
        void Insert(BeeGardenDTO beeGardenDto);
        void Update(BeeGardenDTO beeGardenDto);
        void Delete(int beeGardenId);
        BeeGardenDTO GetBeeGarden(int beeGardenId);
        BeeGardenDTO GetBeeGarden(int beeGardenId, int userId);
        IEnumerable<BeeGardenDTO> GetBeeGardens();
        IEnumerable<BeeGardenDTO> GetBeeGardensByUserId(int userId);
    }
}
