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
			var user = new User
			{
				Id = 2,
				FirstName = "Ivan",
				SecondName = "Bad",
				Birthday = DateTime.Now,
				Email = "ivan@gmail.com",
				Password = "123456",
				Role = "user"
			};

			var admin = new User
			{
				Id = 1,
				FirstName = "Admin",
				SecondName = "admin",
				Birthday = DateTime.Now,
				Email = "admin@gmail.com",
				Password = "admin",
				Role = "admin"
			};

			modelBuilder.Entity<User>().HasData(user);
			modelBuilder.Entity<User>().HasData(admin);

			var beeGarder = new BeeGarden
			{
				Id = 1,
				Name = "Bee Garden 1",
				Description = "Description Bee Garden 1",
				UserId = user.Id
			};
			modelBuilder.Entity<BeeGarden>().HasData(beeGarder);

			var beehive = new Beehive
			{
				Id = 1,
				Name = "Beehive 1",
				Description = "Description Beehives 1",
				NumberOfTheFrames = 10,
				Type = "Dadan",
				YearOfTheQueenBee = 2020,
				BeeGardenId = beeGarder.Id
			};
			modelBuilder.Entity<Beehive>().HasData(beehive);

			var beehive2 = new Beehive
			{
				Id = 2,
				Name = "Beehive 2",
				Description = "Description Beehives 2",
				NumberOfTheFrames = 12,
				Type = "Dadan",
				YearOfTheQueenBee = 2019,
				BeeGardenId = beeGarder.Id
			};
			modelBuilder.Entity<Beehive>().HasData(beehive2);

			var statistics = new Statistics
			{
				Id = 1,
				DateTime = DateTime.Now,
				Temperature = 21.3,
				MoisturePercentage = 50,
				Weight = 85.7,
				Location = "49.82236707355737, 34.532303261131425",
				BeehiveId = beehive.Id
			};
			modelBuilder.Entity<Statistics>().HasData(statistics);

			var statistics2 = new Statistics
			{
				Id = 2,
				DateTime = DateTime.Now,
				Temperature = 22.3,
				MoisturePercentage = 55,
				Weight = 80.7,
				Location = "48.82236707355737, 33.532303261131425",
				BeehiveId = beehive.Id
			};
			modelBuilder.Entity<Statistics>().HasData(statistics2);

			var statistics3 = new Statistics
			{
				Id = 3,
				DateTime = DateTime.Now,
				Temperature = 30.3,
				MoisturePercentage = 70,
				Weight = 70.7,
				Location = "45.82236707355737, 31.532303261131425",
				BeehiveId = beehive.Id
			};
			modelBuilder.Entity<Statistics>().HasData(statistics3);

			base.OnModelCreating(modelBuilder);
		}
	}
}
