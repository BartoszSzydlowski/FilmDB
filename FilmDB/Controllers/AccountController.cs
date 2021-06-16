using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FilmDB.Models;
using FilmDB.ViewModels;
using FilmDB.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
	        if (!ModelState.IsValid)
	        {
		        return View(registerModel);
	        }

            var newUser = new ApplicationUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(newUser, registerModel.Password);
            if (!result.Succeeded)
            {
	            foreach (var error in result.Errors)
	            {
		            ModelState.AddModelError(error.Code, error.Description);
	            }

	            ModelState.AddModelError(string.Empty, "Invalid register attempt");
            }
            else
            {
                var loginResult = await _signInManager.PasswordSignInAsync(registerModel.Username, registerModel.Password, false, false);
                if (loginResult.Succeeded)
                {
                    return RedirectToAction(nameof(FilmController.Index), "Film");
                }
            }
            return View(registerModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(FilmController.Index), "Film");
            }
            else
            {
                ModelState.AddModelError("", "Failed to login");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(FilmController.Index), "Film");
        }
    }
}