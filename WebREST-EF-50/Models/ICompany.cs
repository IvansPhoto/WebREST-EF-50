using System.Collections.Generic;

namespace WebREST_EF_50.Models
{
	public interface ICompanyBase
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public List<Phone> Phones { get; set; }
		public List<Email> Emails { get; set; }
	}

	public interface ICompanyFull : ICompanyBase
	{
		public IUserBase? ResponsibleUser { get; set; }
		public List<Employee> Employees { get; set; }
		public List<Objective> Objectives { get; set; }
		public List<Project> Projects { get; set; }
		public CompanyBase? HqCompany { get; set; }
	}
}