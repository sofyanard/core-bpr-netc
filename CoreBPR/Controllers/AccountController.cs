using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using CoreBPR.Models;

namespace CoreBPR.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.ApplicationUsers
                    .AsNoTracking()
                    .Where(a => a.UserId.ToUpper() == userLoginModel.UserId.ToUpper())
                    .Include(a => a.RefGroup).Include(a => a.RefUnit)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid User.");
                    return View(userLoginModel);
                }

                CustomPasswordHasher customPasswordHasher = new CustomPasswordHasher();

                if (!customPasswordHasher.VerifyPassword(user.Password, userLoginModel.Password))
                {
                    ModelState.AddModelError(string.Empty, "Invalid Password.");
                    return View(userLoginModel);
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserId),
                    new Claim("FullName", user.FullName),
                    new Claim("Password", user.Password),
                    new Claim("GroupId", user.GroupId),
                    new Claim("GroupName", user.RefGroup.GroupName),
                    new Claim("UnitId", user.UnitId),
                    new Claim("UnitName", user.RefUnit.UnitName)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        new AuthenticationProperties { IsPersistent = false }
                    );

                return RedirectToAction("Index", "Home");
            }
            return View(userLoginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
