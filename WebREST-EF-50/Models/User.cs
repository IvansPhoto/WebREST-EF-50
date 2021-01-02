using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class User
	{
		//[JsonPropertyName(DbNames.User.Id)]
		public long Id { get; set; }
		
		[Required]
		public string Name { get; set; }

		[Required]
		public string Surname { get; set; }
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();

		public List<Objective> Objectives { get; set; } = new();
		public List<Company> Companies { get; set; } = new();
		public List<Employee> Employees { get; set; } = new();
		public List<Project> Projects { get; set; } = new();
		
		public User(string name, string surname)
		{
			Name = name;
			Surname = surname;
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
		}
	}
}