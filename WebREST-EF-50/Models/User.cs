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

		public User(string name, string surname, List<Phone> phones) : this(name, surname)
		{
			Phones = phones;
		}
		
		public User(string name, string surname, List<Email> emails) : this(name, surname)
		{
			Emails = emails;
		}
		public User(string name, string surname, List<Phone> phones, List<Email> emails) : this(name, surname)
		{
			Phones = phones;
			Emails = emails;
		}
		public User(long id, string name, string surname, List<Phone> phones, List<Email> emails) : this(name, surname)
		{
			Id = id;
			Phones = phones;
			Emails = emails;
		}

		// <summary>
		// Admin is a User with extended rights to manipulate with data of all users.
		// TODO: Check to work this nested class with EF in single table or make a separate class. 
		// </summary>
		// class Admin : User
		// {
		// 	public AccessLevel Access { get; set; }
		//
		// 	public enum AccessLevel
		// 	{
		// 		LocalAdmin = 0,
		// 		SuperVisor = 1
		// 	}
		// 	public Admin(string name, List<Phone> phones, List<Email> emails, AccessLevel access,
		// 		string surname = Defaults.String)
		// 		: base(name, surname, phones, emails)
		// 	{
		// 		Access = access;
		// 	}
		// 	public Admin(long id, string name, List<Phone> phones, List<Email> emails, AccessLevel access,
		// 		string surname = Defaults.String)
		// 		: base(id, name, surname, phones, emails)
		// 	{
		// 		Access = access;
		// 	}
		// }
	}
}