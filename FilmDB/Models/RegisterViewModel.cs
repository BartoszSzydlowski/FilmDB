using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FilmDB.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Username is required")]
		public string Username { get; set; }

		[EmailAddress]
		[Required(ErrorMessage = "Email is required")]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[DisplayName("Confirm password")]
		[Compare("Password", ErrorMessage = "Confirm password doesn't match")]
		public string ConfirmPassword { get; set; }
	}
}