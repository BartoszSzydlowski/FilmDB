using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FilmDB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        private readonly UserManager<ApplicationUserModel> _userManager;

        public AccountController(SignInManager<ApplicationUserModel> signInManager, UserManager<ApplicationUserModel> userManager)
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

            var newUser = new ApplicationUserModel
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
				return RedirectToAction("Index", "Film");
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
        public async Task<IActionResult> Login(RegisterViewModel model)
        {
            IActionResult response = Unauthorized();
            var user = await _userManager.FindByNameAsync(model.Username);
            var checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);

            return response;
        }
    }
}
