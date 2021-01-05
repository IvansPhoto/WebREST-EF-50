using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class Company
	{
		public long Id { get; set; }
		
		[Required]
		public string Name { get; set; }

		[Required]
		public User ResponsibleUser { get; set; }
		
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();
		public string Address { get; set; } = string.Empty;
		public List<Employee> Employees { get; set; } = new();
		public Company? HqCompany { get; set; }

		public Company(string name)
		{
			Name = name;
		}
	}
}