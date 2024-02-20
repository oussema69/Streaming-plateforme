using Microsoft.EntityFrameworkCore;

namespace back_wachify.Model
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Utilisateur> utilisateurs { get; set; }

	}
}
