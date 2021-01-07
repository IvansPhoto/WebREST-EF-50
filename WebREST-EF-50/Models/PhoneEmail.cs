using System;
using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models
{
	public class Phone
	{
		public long Id { get; set; }
		public string PhoneNumber { get; set; } = String.Empty;
		public ContactType Type { get; set; } = ContactType.Unknown;

		public Phone()
		{
		}

		public class Full : Phone
		{
			public User? User { get; set; }
			public Company? Company { get; set; }
			public Employee? Employee { get; set; }

			public Full()
			{
			}

			public Full(Phone phone)
			{
				Id = phone.Id;
				PhoneNumber = phone.PhoneNumber;
				Type = phone.Type;
			}
		}
	}

	public class Email
	{
		public long Id { get; set; }
		public string EmailAddress { get; set; } = string.Empty;
		public ContactType Type { get; set; } = ContactType.Unknown;

		public Email()
		{
		}

		public class Full : Email
		{
			public User? User { get; set; }
			public Company? Company { get; set; }
			public Employee? Employee { get; set; }

			public Full()
			{
			}

			public Full(Email email)
			{
				Id = email.Id;
				EmailAddress = email.EmailAddress;
				Type = email.Type;
			}
		}
	}

	public enum ContactType
	{
		Unknown,
		Private,
		Corporate
	}
}