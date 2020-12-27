using System;
using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class Objective
	{
		public long Id { get; set; }
		public ObjType ObjectType { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
		public bool IsFinished { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime FinishDate { get; set; }
		public Company Company { get; set; }
		public Employee Employee { get; set; }
		public Project? Project { get; set; }
		public User ResponsibleUser { get; set; }

		public enum ObjType
		{
			Call,
			Visit,
			Meeting,
			Message,
			Demonstration
		}

		public Objective(string title, DateTime createDate, DateTime finishDate, User responsibleUser, Project project, string description,
			bool isFinished = false, ObjType objectType = ObjType.Call)
		{
			ObjectType = objectType;
			Title = title;
			Description = description;
			IsFinished = isFinished;
			CreateDate = createDate;
			FinishDate = finishDate;
			ResponsibleUser = responsibleUser;
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