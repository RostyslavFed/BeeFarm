using System;

namespace BeeFarm.BLL.DTO
{
	public class BeeGardenDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public Guid? UserId { get; set; }
	}
}
