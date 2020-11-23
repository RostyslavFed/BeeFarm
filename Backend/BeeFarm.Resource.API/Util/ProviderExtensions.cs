using BeeFarm.BLL.Interfaces;
using BeeFarm.BLL.Services;
using BeeFarm.DAL.Interfaces;
using BeeFarm.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BeeFarm.Resource.API.Util
{
	public static class ProviderExtensions
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddSingleton<IBeeGardenService, BeeGardenService>();
			services.AddSingleton<IBeehiveService, BeehiveService>();
			services.AddSingleton<IStatisticsService, StatisticsService>();
			services.AddSingleton<IUserService, UserService>();
		}

		public static void AddContextService(this IServiceCollection services, string connetionString)
		{
			services.AddSingleton<IUnitOfWork>(new UnitOfWork(connetionString));
		}
	}
}
