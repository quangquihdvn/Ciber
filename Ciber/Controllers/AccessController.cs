using Ciber.Models.Request;
using Ciber.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ciber.Controllers
{
    public class AccessController : Controller
    {
        private readonly ILoginService _loginService;

        public AccessController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _loginService.Login(request);
            if (user == null)
            {
                ViewData["ValidateMessage"] = "User not found";
                return View();
            }

            var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Surname, user.FullName)
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {

                AllowRefresh = true,
                IsPersistent = request.KeepLoggedIn
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

            return RedirectToAction("Index", "Home");
        }
    }
}
