using Microsoft.AspNetCore.Identity;
using BeeFarm.DAL.Entity;
using BeeFarm.DAL.EF;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BeeFarm.DAL.Identity
{
	public class UserManager : UserManager<User>
	{
		public UserManager(BeeFarmContext beeFarmContext)
			: base(new UserStore<User>(beeFarmContext),
				  null, null, null, null, null, null, null, null)
		{
		}
	}
}
