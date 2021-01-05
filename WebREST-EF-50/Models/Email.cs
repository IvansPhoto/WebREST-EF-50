using System.ComponentModel.DataAnnotations;
using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class Email
	{
		public long Id { get; set; }
		
		[Required]
		public string EmailAddress { get; set; }

		public ContactType Type { get; set; } = ContactType.Unknown;
		// public User? User { get; set; }
		// public Company? Company { get; set; }
		// public Employee? Employee { get; set; }

		public Email(string emailAddress)
		{
			EmailAddress = emailAddress;
		}
	}
}