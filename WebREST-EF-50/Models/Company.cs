using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models
{
	public class Company
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();

		public Company()
		{
		}

		public class Full : Company
		{
			public User? ResponsibleUser { get; set; }
			public List<Employee> Employees { get; set; } = new();
			public List<Objective> Objectives { get; set; } = new();
			public List<Project> Projects { get; set; } = new();
			public Company? HqCompany { get; set; }

			public Full()
			{
			}

			public Full(Company company)
			{
				Id = company.Id;
				Name = company.Name;
				Address = company.Address;
				Phones = company.Phones;
				Emails = company.Emails;
			}
		}
	}
}