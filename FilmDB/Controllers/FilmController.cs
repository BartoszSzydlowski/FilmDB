using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmDB.Controllers
{
	public class FilmController : Controller
	{
		private readonly IFilmManager _filmManager;

		public FilmController(IFilmManager filmManager)
		{
			_filmManager = filmManager;
		}

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