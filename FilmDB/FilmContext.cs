using FilmDB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmDB
{
	public class FilmContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<FilmModel> Films { get; set; }

		public FilmContext(DbContextOptions<FilmContext> options) : base(options)
		{
		}
	}
}