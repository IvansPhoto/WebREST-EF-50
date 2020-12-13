namespace WebREST_EF_50.Models
{
	public class Email
	{
		private ContactType _type;
		public long Id { get; set; }

		public ContactType? Type
		{
			get => _type;
			set => _type = value ?? ContactType.Unknown;
		}

		public Email(long id, ContactType type = ContactType.Unknown)
		{
			Id = id;
			Type = type;
		}
	}
}