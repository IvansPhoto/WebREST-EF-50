using System;
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
		public string? Surname { get; set; } = string.Empty;
		public List<Phone> Phones { get; set; } = new List<Phone>();
		public List<Email> Emails { get; set; } = new List<Email>();
		public Company? Company { get; set; }
		
		public Employee(string name)
		{
			Name = name;
		}

		public Employee(string name, string surname) : this(name)
		{
			Surname = surname;
		}
	}
}