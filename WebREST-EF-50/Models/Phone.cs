namespace WebREST_EF_50.Models
{
	public class Phone
	{
		private ContactType _type;
		public long Id { get; set; }

		public ContactType? Type
		{
			get => _type;
			set => _type = value ?? ContactType.Unknown;
		}

		public Phone(long id, ContactType type = ContactType.Unknown)
		{
			Id = id;
			Type = type;
		}
	}
}