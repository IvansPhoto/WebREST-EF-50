namespace WebREST_EF_50.Assistants
{
	public static class DbNames
	{
		public static class Obj
		{
			/// <summary>
			/// The name of the table.
			/// </summary>
			public const string Table = "Objectives";

			public const string Id = "ObjId";
			public const string Title = "Title";
			public const string Description = "Description";
			public const string UserId = "UserId";
			public const string ProjectId = "ProjectId";
			public const string IsCompleted = "IsCompleted";
		}

		public static class Project
		{
			/// <summary>
			/// The name of the table.
			/// </summary>
			public const string Table = "Projects";

			public const string Id = "ProjId";
			public const string Title = "Title";
			public const string UserId = "UserId";
		}

		public static class User
		{
			/// <summary>
			/// The name of the table.
			/// </summary>
			public const string Table = "Users";

			public const string Id = "UsesId";
			public const string Name = "Name";
			public const string Surname = "Surname";
		}
	}
}