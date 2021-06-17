using System.ComponentModel.DataAnnotations;

namespace FilmDB.Models
{
	public class FilmModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		//[Required]
		//public string Genre { get; set; }

		[Required]
		public int Year { get; set; }

		[Required]
		public ActorModel Actor { get; set; }
		 
        [Required]
		public GenreModel Genre { get; set; }
	}
}