using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TasksToDo.Models;
using TasksToDo.Services;
using TasksToDo.ViewModels.Login;

namespace TasksToDo.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        // [Route("login")]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        // [Route("login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var (isValid, user) = await _userService.ValidateUserCredentialsAsync(model.UserName, model.Password);
                if (isValid)
                {
                    await LoginAsync(user);
                    HttpContext.Session.SetString("LoggedUser", user.UserId.ToString());
                    // if (IsUrlValid(model.ReturnUrl))
                    // {
                    //    return Redirect(model.ReturnUrl);
                    //}
                    var loggedUser = HttpContext.Session.GetString("LoggedUser");
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("InvalidCredentials", "Invalid credentials.");
            }

            return View(model);
        }

        private async Task LoginAsync(Users user)
        {
            var properties = new AuthenticationProperties
            {
                //AllowRefresh = false,
                //IsPersistent = true,
                //ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(10)
            };
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
             };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal, properties);
        }

    }
}
