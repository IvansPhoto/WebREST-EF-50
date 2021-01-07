using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models
{
	public class UserBaseBase : IUserBase
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();
		public UserAccessLevel UserAccessLevel { get; set; } = UserAccessLevel.User;

		public UserBaseBase()
		{
		}
	}

	public class UserBaseFull : IUserBase, IUserFull
	{
		public long Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public List<Phone> Phones { get; set; } = new();
		public List<Email> Emails { get; set; } = new();
		public UserAccessLevel UserAccessLevel { get; set; } = UserAccessLevel.User;

		public List<Objective> Objectives { get; set; } = new();
		public List<Company> Companies { get; set; } = new();
		public List<Employee> Employees { get; set; } = new();
		public List<Project> Projects { get; set; } = new();

		public UserBaseFull()
		{
		}

		public UserBaseFull(IUserBase userBaseBase)
		{
			Id = userBaseBase.Id;
			Name = userBaseBase.Name;
			Surname = userBaseBase.Surname;
			Phones = userBaseBase.Phones;
			Emails = userBaseBase.Emails;
			UserAccessLevel = userBaseBase.UserAccessLevel;
		}
	}

	public enum UserAccessLevel
	{
		User = 0,
		LocalAdmin = 1,
		SuperVisor = 2
	}
}