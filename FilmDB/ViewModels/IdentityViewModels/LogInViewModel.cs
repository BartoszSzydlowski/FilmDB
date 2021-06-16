using System.ComponentModel.DataAnnotations;

namespace FilmDB.ViewModels.IdentityViewModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Login is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
