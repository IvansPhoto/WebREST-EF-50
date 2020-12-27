using WebREST_EF_50.Assistants;

namespace WebREST_EF_50.Models
{
	public class Phone
	{
		public long Id { get; set; }

		public string PhoneNumber { get; set; }
		
		public ContactType Type { get; set; }
		
		public Phone(string phoneNumber = Defaults.String, ContactType type = ContactType.Unknown)
		{
			PhoneNumber = phoneNumber;
			Type = type;
		}

		public Phone(long id, ContactType type, string number) : this(number, type)
		{
			Id = id;
		}
	}
}