using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models.AdvModels
{
	public class Company
	{
		public long Id { get; set; }

		[Required] public string Name { get; set; }

		[Required] public User ResponsibleUser { get; set; }

		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();
		public string Address { get; set; } = string.Empty;

		public Company(string name)
		{
			Name = name;
		}

		class Full : Company
		{
			public List<Employee> Employees { get; set; } = new();
			public List<Objective> Objectives { get; set; } = new();
			public List<Project> Projects { get; set; } = new();
			public Company? HqCompany { get; set; }

			public Full(string name) : base(name)
			{
			}
		}
	}
}