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

		public DbSet<User> Users { get; set; }
		public DbSet<User.Admin> Admins { get; set; }
		public DbSet<Company> Company { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Objective> Objectives { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Email> Emails { get; set; }
		public DbSet<Phone> Phones { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=crm.db");

	}
}
