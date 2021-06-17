using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB
{
    public static class CustomRoles
    {
        public const string Admin = "Admin";
        public const string Moderator = "Moderator";
        public const string AdminOrModerator = "Admin" + ", " + "Moderator";
    }
}
