using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmDB.Models;
using FilmDB.ViewModels;
using FilmDB.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FilmDB.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRole = new IdentityRole()
                {
                    Name = model.Name
                };
                var result = await _roleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(FilmController.Index), "Film");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error creating new role");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Remove(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }
    }
}
