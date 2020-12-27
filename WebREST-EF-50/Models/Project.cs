using System;
using System.Text.Json.Serialization;

namespace WebREST_EF_50.Models
{
	public class Project
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public User ResponsibleUser { get; set; }
		public string? Description { get; set; }
		public bool IsFinished { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public Company Company { get; set; }
		public Employee? Employee { get; set; }

		public Project(string title, User responsibleUser, bool isFinished, DateTime startDate, DateTime finishDate, Company company)
		{
			Title = title;
			ResponsibleUser = responsibleUser;
			IsFinished = isFinished;
			StartDate = startDate;
			FinishDate = finishDate;
			Company = company;
		}

		public Project(string title, User responsibleUser, string? description, bool isFinished, DateTime startDate, DateTime finishDate, Company company) :
			this(title, responsibleUser, isFinished, startDate, finishDate, company)
		{
			Description = description;
		}

		public Project(string title, User responsibleUser, string? description, bool isFinished, DateTime startDate, DateTime finishDate,
			Company company, Employee? employee) : this(title, responsibleUser, description, isFinished, startDate, finishDate, company)
		{
			Employee = employee;
		}
		public Project(long id, string title, User responsibleUser, string? description, bool isFinished, DateTime startDate, DateTime finishDate,
			Company company, Employee? employee) :
			this(title, responsibleUser, isFinished, startDate, finishDate, company)
		{
			Id = id;
			Description = description;
			Employee = employee;
		}
	}
}