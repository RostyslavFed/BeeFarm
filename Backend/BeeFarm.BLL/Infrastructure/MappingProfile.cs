using AutoMapper;
using BeeFarm.BLL.DTO;
using BeeFarm.DAL.Entity;

namespace BeeFarm.BLL.Infrastructure
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<BeeGarden, BeeGardenDTO>();
			CreateMap<Beehive, BeehiveDTO>();
			CreateMap<Statistics, StatisticsDTO>();
			CreateMap<User, UserDTO>();
		}
	}
}
