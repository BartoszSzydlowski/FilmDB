using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmDB.Models;

namespace FilmDB.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmApiController : ControllerBase
    {
        private readonly IFilmManager _filmManager;

        public FilmApiController(IFilmManager filmManager)
        {
            _filmManager = filmManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FilmModel filmModel)
        {
            if (ModelState.IsValid)
            {
                await _filmManager.AddFilm(filmModel);
                return Ok(filmModel);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var film = await _filmManager.GetFilm(id);
            if (film != null)
            {
                return Ok(film);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var films = await _filmManager.GetFilms();
            return Ok(films);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(FilmModel model)
        {
            if (ModelState.IsValid)
            {
                var film = await _filmManager.UpdateFilm(model);
                return Ok(film);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var film = _filmManager.GetFilm(id);
            if (film != null)
            {
                await _filmManager.RemoveFilm(film.Id);
            }
        }
    }
}
