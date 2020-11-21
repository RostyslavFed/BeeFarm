using BeeFarm.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace BeeFarm.DAL.EF
{
	public class BeeFarmContext : DbContext
	{
		public BeeFarmContext(DbContextOptions<BeeFarmContext> options) 
			: base(options)
		{
		}

		public DbSet<User> Users { get; set; }

		public DbSet<BeeGarden> BeeGardens { get; set; }

		public DbSet<Beehive> Beehives { get; set; }

		public DbSet<Statistics> Statistics { get; set; }
	}
}
