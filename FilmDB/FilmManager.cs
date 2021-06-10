using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FilmDB.Models;

namespace FilmDB
{
    public class FilmManager
    {
        private readonly FilmContext _context;

        public FilmManager(FilmContext context)
        {
            _context = context;
        }

        public FilmManager AddFilm(FilmModel filmModel)
        {
            _context.Films.Add(filmModel);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                if (filmModel.Id != 0)
                {
                    filmModel.Id = 0;
                    _context.SaveChanges();
                }
            }
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            var film = _context.Films.SingleOrDefault(x => x.Id == id);
            _context.Films.Remove(film);
            _context.SaveChanges();
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            _context.Films.Update(filmModel);
            _context.SaveChanges();
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            var film = GetFilm(id);
            film.Title = string.IsNullOrEmpty(newTitle) ? "Brak tytulu" : newTitle;
            _context.Films.Update(film);
            _context.SaveChanges();
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            return _context.Films.SingleOrDefault(x => x.Id == id);
        }

        public List<FilmModel> GetFilms()
        {
            return _context.Films.ToList();
        }
    }
}
