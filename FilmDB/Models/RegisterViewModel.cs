using System.ComponentModel.DataAnnotations;

namespace FilmDB.Models
{
	public class RegisterViewModel
	{
		[Required]
		public string Username { get; set; }

		[Required, EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "Confirm password doesn't match")]
		public string ConfirmPassword { get; set; }
	}
}