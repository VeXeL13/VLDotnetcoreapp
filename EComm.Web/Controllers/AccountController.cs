using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EComm.Web.Models;
using EComm.DataAccess;
using EComm.Model;
using Microsoft.EntityFrameworkCore;
using EComm.Web.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace EComm.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login (string ReturnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = ReturnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login (LoginViewModel lvm)
        {
            if (!ModelState.IsValid) return View(lvm);

            bool auth = (lvm.Username == "test" && lvm.Password == "password");

            if (!auth) return View(lvm);

            var principal = new ClaimsPrincipal(
              new ClaimsIdentity(new List<Claim>
              {
                  new Claim(ClaimTypes.Name, lvm.Username),
                  new Claim(ClaimTypes.Role, "Admin")
              }, "FormsAuthentication"));

            await HttpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme,
              principal);

            if (lvm.ReturnUrl != null) return LocalRedirect(lvm.ReturnUrl);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
