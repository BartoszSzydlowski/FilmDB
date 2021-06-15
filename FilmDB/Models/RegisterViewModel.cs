using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }
}
