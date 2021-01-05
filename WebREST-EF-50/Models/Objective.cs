using System;
using System.ComponentModel.DataAnnotations;
using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class Objective
	{
		public long Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public User ResponsibleUser { get; set; }

		public string Description { get; set; } = string.Empty;
		public ObjType ObjectType { get; set; } = ObjType.Call;
		public bool IsFinished { get; set; } = false;
		public DateTime CreateDate { get; set; } = new();
		public DateTime FinishDate { get; set; } = new();
		
		public Company? Company { get; set; }
		public Employee? Employee { get; set; }
		public Project? Project { get; set; }


		public enum ObjType
		{
			Call,
			Visit,
			Meeting,
			Message,
			Demonstration
		}
		
		public Objective(string title)
		{
			Title = title;
		}
	}
}