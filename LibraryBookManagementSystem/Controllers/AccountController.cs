using LibraryBookManagementSystem.Models.Entities;
using LibraryBookManagementSystem.Models.ViewModels;
using LibraryBookManagementSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace LibraryBookManagementSystem.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly ApplicationDbContext db;

    public AccountController(ApplicationDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            User user = await db.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Name == model.Name && u.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Пользователя не существует");
                return View(user);
            }
            if (user != null)
            {
                await Authenticate(user);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Некорректные логин и(или) пароль");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            User user = await db.Users.FirstOrDefaultAsync(u => u.Name == model.Name);
            if (user == null)
            {
                user = new User
                {
                    Name = model.Name,
                    Password = model.Password,
                };
                Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == model.Role);
                if (userRole != null)
                    user.Role = userRole;

                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();

                await Authenticate(user);

                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError(string.Empty, "Некорректные логин и(или) пароль");
        }
        return View(model);
    }

    private async Task Authenticate(User user)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }
}
