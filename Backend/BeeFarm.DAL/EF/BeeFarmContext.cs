using BeeFarm.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BeeFarm.DAL.EF
{
	public class BeeFarmContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<BeeGarden> BeeGardens { get; set; }
		public DbSet<Beehive> Beehives { get; set; }
		public DbSet<Statistics> Statistics { get; set; }

		public BeeFarmContext(DbContextOptions<BeeFarmContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 1,
				FirstName = "Admin",
				SecondName = "admin",
				Birthday = DateTime.Now,
				Email = "admin@gmail.com",
				Password = "admin",
				Role = "admin"
			});

			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 2,
				FirstName = "Ivan",
				SecondName = "Bad",
				Birthday = DateTime.Now,
				Email = "ivan@gmail.com",
				Password = "123456",
				Role = "user"
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}
