using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models
{
	public class CompanyBase : ICompanyBase
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();

		public CompanyBase()
		{
		}
	}

	public class CompanyFull : ICompanyFull
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();
		public IUserBase? ResponsibleUser { get; set; }
		public List<Employee> Employees { get; set; } = new();
		public List<Objective> Objectives { get; set; } = new();
		public List<Project> Projects { get; set; } = new();
		public CompanyBase? HqCompany { get; set; }

		public CompanyFull()
		{
		}

		public CompanyFull(ICompanyBase companyBase)
		{
			Id = companyBase.Id;
			Name = companyBase.Name;
			Address = companyBase.Address;
			Phones = companyBase.Phones;
			Emails = companyBase.Emails;
		}
	}
}