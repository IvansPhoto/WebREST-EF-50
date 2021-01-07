using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models.AdvModels
{
	public class Employee
	{
		public long Id { get; set; }

		[Required] public string Name { get; set; }

		[Required] public User ResponsibleUser { get; set; }
		public string Surname { get; set; } = string.Empty;
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();

		public Employee(string name)
		{
			Name = name;
		}

		public class Full : Employee
		{
			public List<Objective> Objectives { get; set; } = new();
			public Models.Company? Company { get; set; }

			public Full(string name) : base(name)
			{
			}
		}
	}
}