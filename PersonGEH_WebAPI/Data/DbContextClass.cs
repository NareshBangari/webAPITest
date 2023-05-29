using Microsoft.EntityFrameworkCore;
using PersonGEH_WebAPI_Unit_Testing.Model;

namespace PersonGEH_WebAPI_Unit_Testing.Data
{
	public class DbContextClass : DbContext
	{
		protected readonly IConfiguration Configuration;
		public DbContextClass(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
		}

		public DbSet<PersonDetails> PersonDetalisTest { get; set; }
		public DbSet<TechnicalExperience> TechnicalExperiencesTest { get; set; }
	}
}
