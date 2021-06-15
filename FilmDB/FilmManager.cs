using FilmDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmDB
{
	public class FilmManager : IFilmManager
	{
		private readonly FilmContext _context;

		public FilmManager(FilmContext context)
		{
			_context = context;
		}

		public async Task<FilmManager> AddFilm(FilmModel filmModel)
		{
			_context.Films.Add(filmModel);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				if (filmModel.Id != 0)
				{
					filmModel.Id = 0;
					await _context.SaveChangesAsync();
				}
			}
			return this;
		}

		public async Task<FilmManager> RemoveFilm(int id)
		{
			var film = await _context.Films.SingleOrDefaultAsync(x => x.Id == id);
			_context.Films.Remove(film);
			await _context.SaveChangesAsync();
			return this;
		}

		public async Task<FilmManager> UpdateFilm(FilmModel filmModel)
		{
			_context.Films.Update(filmModel);
			await _context.SaveChangesAsync();
			return this;
		}

		public async Task<FilmManager> ChangeTitle(int id, string newTitle)
		{
			var film = await GetFilm(id);
			film.Title = string.IsNullOrEmpty(newTitle) ? "Brak tytulu" : newTitle;
			_context.Films.Update(film);
			await _context.SaveChangesAsync();
			return this;
		}

		public async Task<FilmModel> GetFilm(int id)
		{
			return await _context.Films.SingleOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<FilmModel>> GetFilms()
		{
			return await _context.Films.ToListAsync();
		}
	}
}