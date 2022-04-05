using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using OrganicFoodShop.Data.Models;
using OrganicFoodShop.Models.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFoodShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel user)
        {
            if (!this.ModelState.IsValid)
            {
                //koe e po-dobre??
                // return View(user);
                return this.RedirectToAction(nameof(Register));
            }

            var registeredUser = new User
            {
                Email = user.Email,
                UserName = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
                //ne zadavame parolata, zashtoto trqbva da e heshirana
            };

            //createAsync автоматично ще хешира паролата
            var result = await this.userManager.CreateAsync(registeredUser, user.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel user)
        {
            var loggedUser = await this.userManager.FindByEmailAsync(user.Email);

            if (loggedUser == null)
            {
                InvalidCredentials(user);
            }

            var validPass = await this.userManager.CheckPasswordAsync(loggedUser, user.Password);

            if (!validPass)
            {
                InvalidCredentials(user);
            }

            await this.signInManager.SignInAsync(loggedUser, true);

            return RedirectToAction("Index", "Home");
        }

        private IActionResult InvalidCredentials(LoginFormModel user)
        {
            const string invalidCredentialsMessage = "Invalid credentials!";

            ModelState.AddModelError(string.Empty, invalidCredentialsMessage);

            return View(user);
        }

    }
}
