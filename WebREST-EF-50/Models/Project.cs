using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models
{
	public class Project
	{
		public long Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool IsFinished { get; set; } = false;
		public DateTime StartDate { get; set; } = DateTime.Now;
		public DateTime FinishDate { get; set; } = DateTime.Now;

		public Project()
		{
		}

		public class Full : Project
		{
			public User? ResponsibleUser { get; set; }
			public Company? Company { get; set; }
			public Employee? Employee { get; set; }
			public List<Objective> Objectives { get; set; } = new();

			public Full()
			{
			}

			public Full(Project project)
			{
				Id = project.Id;
				Title = project.Title;
				Description = project.Description;
				IsFinished = project.IsFinished;
				StartDate = project.StartDate;
				FinishDate = project.FinishDate;
			}
		}
	}
}