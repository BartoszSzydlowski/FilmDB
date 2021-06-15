using FilmDB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmDB
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IFilmManager, FilmManager>();

			services.AddDbContext<FilmContext>(options =>
			{
				try
				{
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
				}
				catch
				{
					options.UseSqlServer(configuration.GetConnectionString("BackupConnection"));
				}
			});

			services.AddIdentity<ApplicationUserModel, IdentityRole>(options =>
			{
				options.User.RequireUniqueEmail = true;
			}).AddEntityFrameworkStores<FilmContext>();

			return services;
		}
	}
}