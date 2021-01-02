using System;
using System.ComponentModel.DataAnnotations;
using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class Objective
	{
		public long Id { get; set; }
		public ObjType ObjectType { get; set; } = ObjType.Call;
		
		[Required]
		public string Title { get; set; }
		public string? Description { get; set; } = string.Empty;
		public bool IsFinished { get; set; } = false;
		public DateTime CreateDate { get; set; } = new DateTime();
		public DateTime FinishDate { get; set; } = new DateTime();
		public Company? Company { get; set; }
		public Employee? Employee { get; set; }
		public Project? Project { get; set; }

		[Required]
		public User ResponsibleUser { get; set; }

		public enum ObjType
		{
			Call,
			Visit,
			Meeting,
			Message,
			Demonstration
		}
		
		public Objective(string title, User responsibleUser)
		{
			Title = title;
			ResponsibleUser = responsibleUser;
		}

		public Objective(string title, DateTime createDate, DateTime finishDate, User responsibleUser, string description,
			bool isFinished = false, ObjType objectType = ObjType.Call) : this(title, responsibleUser)
		{
			ObjectType = objectType;
			Description = description;
			IsFinished = isFinished;
			CreateDate = createDate;
			FinishDate = finishDate;
		}

		public Objective(string title, DateTime createDate, DateTime finishDate, User responsibleUser, Project project, string description,
	bool isFinished = false, ObjType objectType = ObjType.Call) : 
			this(title, createDate, finishDate, responsibleUser, description, isFinished, objectType)
		{
			Project = project;
		}


		public Objective(string title, DateTime createDate, DateTime finishDate, User responsibleUser, Company company, Employee employee, Project project,
			string description = Defaults.String, bool isFinished = false, ObjType objectType = ObjType.Call) :
			this(title, createDate, finishDate, responsibleUser, project, description, isFinished, objectType)
		{
			Company = company;
			Employee = employee;
		}

		public Objective(string title, DateTime createDate, DateTime finishDate, User responsibleUser, Employee employee, Company company, Project project,
			string description = Defaults.String, bool isFinished = false, ObjType objectType = ObjType.Call) :
			this(title, createDate, finishDate, responsibleUser, project, description, isFinished, objectType)
		{
			Employee = employee;
			Company = company;
		}

		public Objective(long id, string title, DateTime startDate, DateTime finishingDate, Company company, Employee employee, User responsibleUser, Project project,
			string description = Defaults.String, bool isFinished = false, ObjType objectType = ObjType.Call) :
			this(title, startDate,
				finishingDate, responsibleUser, project, description, isFinished, objectType)
		{
			Id = id;
			Company = company;
			Employee = employee;
		}
	}
}