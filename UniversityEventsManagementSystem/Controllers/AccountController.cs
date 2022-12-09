using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UniversityEventsManagementSystem.Controllers;

public class AccountController : Controller
{
	public IActionResult SignIn() => View();

	[HttpPost]
	public async Task<IActionResult> SignIn(string name, string role)
	{
		await Authenticate(name, role);

		return RedirectToAction("Index", "Home");
	}

	private async Task Authenticate(string name, string role)
	{
		var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, name),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
			};
		ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
			ClaimsIdentity.DefaultRoleClaimType);
		await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
	}

	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		return RedirectToAction("SignIn", "Account");
	}
}
