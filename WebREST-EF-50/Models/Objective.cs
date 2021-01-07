using System;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models
{
	public class Objective
	{
		public long Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool IsFinished { get; set; } = false;
		public ObjType ObjectType { get; set; } = ObjType.Call;
		public DateTime CreateDate { get; set; } = new();
		public DateTime FinishDate { get; set; } = new();

		public enum ObjType
		{
			Call,
			Visit,
			Meeting,
			Message,
			Demonstration
		}

		public Objective()
		{
		}

		public class Full : Objective
		{
			public IUserBase? ResponsibleUser { get; set; }
			public CompanyBase? Company { get; set; }
			public Employee? Employee { get; set; }
			public Project? Project { get; set; }

			public Full()
			{
			}

			public Full(Objective objective)
			{
				Id = objective.Id;
				Title = objective.Title;
				Description = objective.Description;
				IsFinished = objective.IsFinished;
				ObjectType = objective.ObjectType;
				CreateDate = objective.CreateDate;
				FinishDate = objective.FinishDate;
			}
		}
	}
}