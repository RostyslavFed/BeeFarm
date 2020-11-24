using AutoMapper;
using BeeFarm.BLL.DTO;
using BeeFarm.DAL.Entity;

namespace BeeFarm.BLL.Infrastructure
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<BeeGarden, BeeGardenDTO>().ReverseMap();
			CreateMap<Beehive, BeehiveDTO>().ReverseMap();
			CreateMap<Statistics, StatisticsDTO>().ReverseMap();
			CreateMap<User, UserDTO>().ReverseMap();
		}
	}
}
