using System.ComponentModel.DataAnnotations;

namespace FilmDB.ViewModels.RoleViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
