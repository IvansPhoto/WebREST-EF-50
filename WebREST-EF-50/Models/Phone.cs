using System.ComponentModel.DataAnnotations;
using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class Phone
	{
		public long Id { get; set; }
		
		[Required]
		public string PhoneNumber { get; set; }
		
		public ContactType Type { get; set; } = ContactType.Unknown;
		// public User? User { get; set; }
		// public Company? Company { get; set; }
		// public Employee? Employee { get; set; }
		
		public Phone(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}
	}
}