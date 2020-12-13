using System.Text.Json.Serialization;
using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class User
	{
		[JsonPropertyName(DbNames.User.Id)] public long Id { get; set; }

		public string Name { get; set; }
		public Phone? Phone { get; set; }
		public Email? Email { get; set; }
		public string Surname { get; set; }

		public User(long id, string name, Phone phone, Email email, string surname = Defaults.String)
		{
			Id = id;
			Name = name;
			Phone = phone;
			Email = email;
			Surname = surname;
		}


		/// <summary>
		/// Admin is a User with extended rights for changing data of all users.
		/// TODO: Check to work this nested class with EF in single table or make a separate class. 
		/// </summary>
		class Admin : User
		{
			public AccessLevel Access { get; set; }

			public enum AccessLevel
			{
				LocalAdmin = 0,
				SuperVisor = 1
			}

			public Admin(long id, string name, Phone phone, Email email, AccessLevel access, string surname = Defaults.String)
				: base(id, name, phone, email, surname)
			{
				Access = access;
			}
		}
	}
}