using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreMVC.Models;

namespace StoreMVC.Controllers
{
    public class AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : Controller
    {
        private readonly SignInManager<AppUser> signInManager = signInManager;
        private readonly UserManager<AppUser> userManager = userManager;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt!");
                return View(model);
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm model)
        {
            if (ModelState.IsValid) {
                AppUser user = new()
                {
                    Name = model.Name,
                    Email = model.Email,
                    UserName = model.Email,
                    Address = model.Address
                };

                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
