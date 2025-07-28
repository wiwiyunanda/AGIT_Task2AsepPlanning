using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task2AsepPlanning.Models;

namespace Task2AsepPlanning.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Planning> Plannings { get; set; }
	}
}

