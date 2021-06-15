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
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
	        ApplicationUserModel user;
	        try
	        {
		        user = await _userManager.FindByNameAsync(registerModel.Username);
            }
	        catch
	        {
		        return View(registerModel);
            }

            if (user != null)
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
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Film");
            }

            if (!ModelState.IsValid)
            {
	            var passwordErrors = string.Join("\n", result.Errors
		            .Where(x => x.Description.StartsWith("Password")));
	            ModelState.AddModelError("Password", passwordErrors);
	            return View(registerModel);
            }

            return View(registerModel);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
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
