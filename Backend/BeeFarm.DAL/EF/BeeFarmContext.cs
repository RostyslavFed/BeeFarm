using BeeFarm.DAL.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BeeFarm.DAL.EF
{
	public class BeeFarmContext : IdentityDbContext<User>
	{
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
			var userRole = new Role("User");
			modelBuilder.Entity<Role>().HasData(userRole);


			//var user = new User
			//{
			//	Id = Guid.NewGuid().ToString(),
			//	UserName = "Ivan 228",
			//	FirstName = "Ivan",
			//	SecondName = "Bad",
			//	Birthday = DateTime.Now,
			//	Email = "ivan@gmail.com",
			//	Password = "123456",
			//	PasswordHash = "121313sasa"
			//};
			//modelBuilder.Entity<User>().HasData(user);

			base.OnModelCreating(modelBuilder);
		}
	}
}
