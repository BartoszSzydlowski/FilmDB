﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmDB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmDB
{
    public class FilmContext : IdentityDbContext<ApplicationUserModel>
    {
        public DbSet<FilmModel> Films { get; set; }

        public FilmContext(DbContextOptions<FilmContext> options) : base(options) { }
    }
}
