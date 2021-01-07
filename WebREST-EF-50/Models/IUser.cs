using System.Collections.Generic;

namespace WebREST_EF_50.Models
{
	public interface IUserBase
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public List<Phone> Phones { get; set; }
		public List<Email> Emails { get; set; }
		public UserAccessLevel UserAccessLevel { get; set; }
	}

	public interface IUserFull
	{
		public List<Objective> Objectives { get; set; }
		public List<Company> Companies { get; set; }
		public List<Employee> Employees { get; set; }
		public List<Project> Projects { get; set; }
	}
}