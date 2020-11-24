using Microsoft.Extensions.DependencyInjection;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.EF;

namespace BeeFarm.DAL.Util
{
	public static class ProviderExtensions
	{
		public static void AddIdentityService(this IServiceCollection services)
		{
			services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<BeeFarmContext>();
		}
	}
}
