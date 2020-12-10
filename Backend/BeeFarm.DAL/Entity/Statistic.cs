﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeFarm.DAL.Entity
{
	public class Statistic
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public DateTime DateTime { get; set; }

		public double Temperature { get; set; }

		public int Humidity { get; set; }

		public double Weight { get; set; }

		[StringLength(50)]
		public string Location { get; set; }


		public int? BeehiveId { get; set; }

		public virtual Beehive Beehive { get; set; }
	}
}
