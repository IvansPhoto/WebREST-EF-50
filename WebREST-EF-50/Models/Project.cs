using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebREST_EF_50.Models
{
	public class Project
	{
		public long Id { get; set; }
		
		[Required]
		public string Title { get; set; }
		
		[Required]
		public User ResponsibleUser { get; set; }

		public string? Description { get; set; } = string.Empty;
		public bool IsFinished { get; set; } = false;
		public DateTime StartDate { get; set; } = new();
		public DateTime FinishDate { get; set; } = new();
		public Company? Company { get; set; }
		public Employee? Employee { get; set; }

		public Project(string title, bool isFinished = false, DateTime startDate = new(), DateTime finishDate = new())
		{
			Title = title;
			IsFinished = isFinished;
			StartDate = startDate;
			FinishDate = finishDate;
		}
	}
}