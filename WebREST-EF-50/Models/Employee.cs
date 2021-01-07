using System.Collections.Generic;

namespace WebREST_EF_50.Models
{
	public class Employee
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();

		public Employee()
		{
		}


		public class Full : Employee
		{
			public User? ResponsibleUser { get; set; }
			public Company? Company { get; set; }
			public List<Objective> Objectives { get; set; } = new();
			public List<Project> Projects { get; set; } = new();

			public Full()
			{
			}

			public Full(Employee employee)
			{
				Id = employee.Id;
				Name = employee.Name;
				Surname = employee.Surname;
				Phones = employee.Phones;
				Emails = employee.Emails;
			}
		}
	}
}