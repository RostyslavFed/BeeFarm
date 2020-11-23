using AutoMapper;
using BeeFarm.BLL.Interfaces;
using BeeFarm.BLL.Services;
using BeeFarm.DAL.Interfaces;
using BeeFarm.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BeeFarm.BLL.Infrastructure
{
	public static class ProviderExtensions
	{
		public static void AddContextService(this IServiceCollection services, string connectionString)
		{
			services.AddSingleton<IUnitOfWork>(new UnitOfWork(connectionString));
		}

		public static void AddAutoMapper(this IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddSingleton<IBeeGardenService, BeeGardenService>();
			services.AddSingleton<IBeehiveService, BeehiveService>();
			services.AddSingleton<IStatisticsService, StatisticsService>();
			services.AddSingleton<IUserService, UserService>();
		}
	}
}
