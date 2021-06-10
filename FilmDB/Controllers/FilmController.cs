using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmManager _filmManager;
        

        public FilmController(FilmManager filmManager)
        {
            _filmManager = filmManager;
        }
        public IActionResult Index()
        {
            //var film = new FilmModel()
            //{
            //    Title = "Tytul 10",
            //    Genre = "Gatunek 10",
            //    Year = 2000
            //};

            //_filmManager.AddFilm(film);

            //ViewBag.FilmTitle = film.Title;
            //ViewBag.FilmGenre = film.Genre;
            //ViewBag.FilmYear = film.Year;

            //_filmManager.RemoveFilm(10);
            
            //var film = _filmManager.GetFilm(2);
            //film.Title = "edited title";
            //film.Genre = "edited genre";
            //film.Year = 2001;
            //_filmManager.UpdateFilm(film);

            //_filmManager.ChangeTitle(4, null);

            var films = _filmManager.GetFilms();

            ViewBag.Films = films;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(FilmModel filmModel)
        {
            if (ModelState.IsValid)
            {
                _filmManager.AddFilm(filmModel);
            }
            return null;
        }
    }
}
