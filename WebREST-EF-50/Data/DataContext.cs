using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) {}

		public DbSet<IUserFull> UsersFull { get; set; }
		public DbSet<Company.Full> CompaniesFull { get; set; }
		public DbSet<Employee.Full> EmployeesFull { get; set; }
		public DbSet<Objective.Full> ObjectivesFull { get; set; }
		public DbSet<Project.Full> ProjectsFull { get; set; }
		public DbSet<Email.Full> EmailsFull { get; set; }
		public DbSet<Phone.Full> PhonesFull { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=crm.db");

	}
}
