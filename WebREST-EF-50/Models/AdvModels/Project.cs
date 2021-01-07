using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models.AdvModels
{
	public class Project
	{
		public long Id { get; set; }

		[Required] public string Title { get; set; }

		[Required] public User ResponsibleUser { get; set; }

		public string Description { get; set; } = string.Empty;
		public bool IsFinished { get; set; } = false;
		public DateTime StartDate { get; set; } = DateTime.Now;
		public DateTime FinishDate { get; set; } = DateTime.Now;

		public Project(string title)
		{
			Title = title;
		}

		public class Full : Project
		{
			public List<Objective> Objectives { get; set; } = new();
			public Models.Company? Company { get; set; }
			public Employee? Employee { get; set; }

			public Full(string title) : base(title)
			{
			}
		}
	}
}