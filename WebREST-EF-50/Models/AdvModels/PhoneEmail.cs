using System.ComponentModel.DataAnnotations;

namespace WebREST_EF_50.Models.AdvModels
{
	public class Phone
	{
		public long Id { get; set; }

		[Required] public string PhoneNumber { get; set; }
		public ContactType Type { get; set; } = ContactType.Unknown;

		public Phone(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}

		public class Full : Phone
		{
			public User? User { get; set; }
			public Models.Company? Company { get; set; }
			public Employee? Employee { get; set; }

			public Full(string phoneNumber) : base(phoneNumber)
			{
			}
		}
	}

	public class Email
	{
		public long Id { get; set; }

		[Required] public string EmailAddress { get; set; }

		public ContactType Type { get; set; } = ContactType.Unknown;


		public Email(string emailAddress)
		{
			EmailAddress = emailAddress;
		}

		public class Full : Email
		{
			public User? User { get; set; }
			public Models.Company? Company { get; set; }
			public Employee? Employee { get; set; }

			public Full(string emailAddress) : base(emailAddress)
			{
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