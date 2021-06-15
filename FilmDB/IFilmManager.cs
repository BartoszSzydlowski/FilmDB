using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmDB.Models;

namespace FilmDB
{
    public interface IFilmManager
    {
        Task<FilmManager> AddFilm(FilmModel filmModel);
        Task<FilmManager> RemoveFilm(int id);
        Task<FilmManager> UpdateFilm(FilmModel filmModel);
        Task<FilmManager> ChangeTitle(int id, string newTitle);
        Task<FilmModel> GetFilm(int id);
        Task<List<FilmModel>> GetFilms();
    }
}
