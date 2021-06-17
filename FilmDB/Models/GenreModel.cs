using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB.Models
{
    public class GenreModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}
