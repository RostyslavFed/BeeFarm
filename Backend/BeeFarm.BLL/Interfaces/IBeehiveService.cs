using BeeFarm.BLL.DTO;
using System.Collections.Generic;

namespace BeeFarm.BLL.Interfaces
{
	public interface IBeehiveService
	{
		void Insert(BeehiveDTO beehiveDto);
		void Update(BeehiveDTO beehiveDto);
		void Delete(int id);
		BeehiveDTO GetBeehive(int id);
		IEnumerable<BeehiveDTO> GetBeehives();
	}
}
