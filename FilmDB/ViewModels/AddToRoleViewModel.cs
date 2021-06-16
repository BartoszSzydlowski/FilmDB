using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using FilmDB.Models;
using Microsoft.AspNetCore.Identity;

namespace FilmDB.ViewModels
{
    public class AddToRoleViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public string userId { get; set; }
        public string roleId { get; set; }
    }
}
