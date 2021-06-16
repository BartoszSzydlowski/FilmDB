using System;
using FilmDB.Models;
using FilmDB.ViewModels;
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

            services.AddScoped<AddToRoleViewModel>();

            services.AddDbContext<FilmContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BackupConnection"));
            });
			

			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.User.RequireUniqueEmail = true;
			}).AddEntityFrameworkStores<FilmContext>();

			return services;
		}
	}
}