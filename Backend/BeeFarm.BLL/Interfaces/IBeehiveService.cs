using BeeFarm.BLL.BusinessModels;
using BeeFarm.BLL.DTO;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IBeehiveService
	{
		void Insert(BeehiveDTO beehiveDto);
		void Update(BeehiveDTO beehiveDto);
		void Delete(int beehiveId);
		BeehiveDTO GetBeehive(int beehiveId);
		BeehiveDTO GetBeehive(int beehiveId, int beeGardenId);
		IEnumerable<BeehiveDTO> GetBeehives();
		IEnumerable<BeehiveDTO> GetBeehives(int beeGardenId);
		State GetBeehiveState(int beehiveId);
	}
}
