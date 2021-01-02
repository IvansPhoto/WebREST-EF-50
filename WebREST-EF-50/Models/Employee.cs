using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class Employee
	{
		public long Id { get; set; }
		[Required]
		public string Name { get; set; }
		
		[Required]
		public User ResponsibleUser { get; set; }
		public string? Surname { get; set; }
		public List<Phone> Phones { get; set; } = new List<Phone>();
		public List<Email> Emails { get; set; } = new List<Email>();
		public Company? Company { get; set; }
		
		public Employee(string name, User responsibleUser)
		{
			Name = name;
			ResponsibleUser = responsibleUser;
		}
		public Employee(string name, string surname,  User responsibleUser) : this(name, responsibleUser)
		{
			Surname = surname;
		}
		public Employee(string name, string surname, User responsibleUser, Company company) : this(name, surname, responsibleUser)
		{
			Company = company;
		}

		public Employee(string name, string surname, User responsibleUser, Company company, List<Phone> phones) : 
			this(name, surname, responsibleUser, company)
		{
			Phones = phones;
		}
		
		public Employee(string name, string surname, User responsibleUser, Company company, List<Email> emails) : 
			this(name, surname, responsibleUser, company)
		{
			Emails = emails;
		}
		
		public Employee(string name, string surname, User responsibleUser, Company company, List<Phone> phoneses, List<Email> emails) : 
			this(name, surname, responsibleUser, company)
		{
			Phones = phoneses;
			Emails = emails;
		}
		
		public Employee(long id, string name, string surname, User responsibleUser, Company company, List<Phone> phoneses, List<Email> emails) : 
			this(name, surname, responsibleUser, company)
		{
			Id = id;
			Phones = phoneses;
			Emails = emails;
		}

	}
}