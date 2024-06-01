using Identity.Mvc.Dtos.AccountDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLoginDto()
            {
                ReturnUrl = returnUrl,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user is null)
                {
                    ModelState.AddModelError(nameof(model.UserName), "User not found");
                    return View(model);
                }

                if (user != null && !(await signInManager.CheckPasswordSignInAsync(user, model.Password, true)).Succeeded)
                {
                    ModelState.AddModelError(nameof(model.Password), "Password is not valid");
                    return View(model);
                }

                await signInManager.SignInAsync(user, model.RememberMe);

                return Redirect(string.IsNullOrEmpty(model.ReturnUrl) ? "/" : model.ReturnUrl);

            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
