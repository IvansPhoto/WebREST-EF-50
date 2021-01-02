using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class Email
	{
		public long Id { get; set; }

		public string EmailAddress { get; set; } = string.Empty;

		public ContactType Type { get; set; } = ContactType.Unknown;
		
		public Email(string emailAddress, ContactType type = ContactType.Unknown)
		{
			EmailAddress = emailAddress;
			Type = type;
		}

		public Email(long id, ContactType type, string emailAddress) : this(emailAddress, type)
		{
			Id = id;
		}
	}
}