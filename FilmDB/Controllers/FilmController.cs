using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Controllers
{
	public class FilmController : Controller
	{
		private readonly FilmManager _filmManager;
        
		public FilmController(FilmManager filmManager)
		{
			_filmManager = filmManager;
		}

        //public async Task<IActionResult> Index()
        //{
        //    var film = new FilmModel()
        //    {
        //        Title = "Tytul 10",
        //        Genre = "Gatunek 10",
        //        Year = 2000
        //    };
        //    _filmManager.AddFilm(film);
        //    ViewBag.FilmTitle = film.Title;
        //    ViewBag.FilmGenre = film.Genre;
        //    ViewBag.FilmYear = film.Year;
        //    _filmManager.RemoveFilm(10);
        //    var film = _filmManager.GetFilm(2);
        //    film.Title = "edited title";
        //    film.Genre = "edited genre";
        //    film.Year = 2001;
        //    _filmManager.UpdateFilm(film);
        //    _filmManager.ChangeTitle(4, null);
        //    var films = await _filmManager.GetFilms();
        //    ViewBag.Films = films;
        //    return View();
        //}

        public async Task<IActionResult> Index()
		{
			var films = await _filmManager.GetFilms();
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
		public async Task<IActionResult> Add(FilmModel filmModel)
		{
			if (ModelState.IsValid)
			{
				await _filmManager.AddFilm(filmModel);
			}
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Remove(int id)
		{
			var film = await _filmManager.GetFilm(id);
			return View(film);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ConfirmRemove(int id)
		{
			if (id != 0)
			{
				await _filmManager.RemoveFilm(id);
			}
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var film = await _filmManager.GetFilm(id);
			return View(film);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(FilmModel filmModel)
		{
			if (ModelState.IsValid)
			{
				await _filmManager.UpdateFilm(filmModel);
			}
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var film = await _filmManager.GetFilm(id);
            return View(film);
        }
	}
}