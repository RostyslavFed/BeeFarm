using Microsoft.AspNetCore.Identity;

namespace BeeFarm.DAL.Entity
{
	public class Role : IdentityRole
	{
		public Role()
		{
		}

		public Role(string roleName)
			: base(roleName)
		{
		}
	}
}