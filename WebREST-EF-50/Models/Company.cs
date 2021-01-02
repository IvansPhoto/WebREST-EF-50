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
		public User? ResponsibleUser { get; set; }
		public string? Address { get; set; }
		public List<Phone> Phones { get; set; } = new List<Phone>();
		public List<Email> Emails { get; set; } = new List<Email>();
		public Company? HqCompany { get; set; }

		public Company(string name, User responsibleUser)
		{
			Name = name;
			ResponsibleUser = responsibleUser;
		}

		public Company(string name, User responsibleUser, string address) : 
			this(name, responsibleUser)
		{
			Address = address;
		}

		public Company(string name, User responsibleUser, string address, Company hqCompany) : 
			this(name, responsibleUser, address)
		{
			HqCompany = hqCompany;
		}
		public Company(string name, User responsibleUser, string address, Company hqCompany, List<Phone> phoneses) : 
			this(name, responsibleUser, address, hqCompany)
		{
			Phones = phoneses;
		}
		public Company(string name, User responsibleUser, string address, Company hqCompany, List<Email> emailses) : 
			this(name, responsibleUser, address, hqCompany)
		{
			Emails = emailses;
		}
		public Company(long id, string name, User responsibleUser, string address, Company hqCompany, List<Phone> phoneses, List<Email> emailses) : 
			this(name, responsibleUser, address, hqCompany)
		{
			Id = id;
			Phones = phoneses;
			Emails = emailses;
		}
	}
}