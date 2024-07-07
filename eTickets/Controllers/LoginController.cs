using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;


        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Movies");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }
    }
}

