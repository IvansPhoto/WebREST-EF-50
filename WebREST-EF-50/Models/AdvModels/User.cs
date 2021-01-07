using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models.AdvModels
{
	public class User
	{
		public long Id { get; set; }

		[Required] public string Name { get; set; }

		[Required] public string Surname { get; set; }
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();

		public User(string name, string surname)
		{
			Name = name;
			Surname = surname;
		}

		public class Full : User
		{
			public List<Objective> Objectives { get; set; } = new();
			public List<Models.Company> Companies { get; set; } = new();
			public List<Employee> Employees { get; set; } = new();
			public List<Project> Projects { get; set; } = new();

			public Full(string name, string surname) : base(name, surname)
			{
			}
		}

		/// <summary>
		/// Admin is a User with extended rights to manipulate with data of all users.
		/// TODO: Check to work this nested class with EF in single table or make a separate class. 
		/// </summary>
		public class Admin : User
		{
			public AccessLevel Access { get; set; }

			public enum AccessLevel
			{
				LocalAdmin = 0,
				SuperVisor = 1
			}

			public Admin(string name, string surname, AccessLevel access)
				: base(name, surname)
			{
				Access = access;
			}

			public class Full : User
			{
				public List<Objective> Objectives { get; set; } = new();
				public List<Models.Company> Companies { get; set; } = new();
				public List<Employee> Employees { get; set; } = new();
				public List<Project> Projects { get; set; } = new();

				public Full(string name, string surname) : base(name, surname)
				{
				}
			}
		}
	}
}