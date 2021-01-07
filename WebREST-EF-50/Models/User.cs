using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models
{
	public class User
	{
		public long Id { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;

		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();
		public AccessLevel Access { get; set; } = AccessLevel.User;

		public enum AccessLevel
		{
			User = 0,
			LocalAdmin = 1,
			SuperVisor = 2
		}

		public User()
		{
		}

		public class Full : User
		{
			public List<Objective> Objectives { get; set; } = new();
			public List<Company> Companies { get; set; } = new();
			public List<Employee> Employees { get; set; } = new();
			public List<Project> Projects { get; set; } = new();

			public Full()
			{
			}

			public Full(User user)
			{
				Id = user.Id;
				Name = user.Name;
				Surname = user.Surname;
				Phones = user.Phones;
				Emails = user.Emails;
				Access = user.Access;
			}
		}
	}
}