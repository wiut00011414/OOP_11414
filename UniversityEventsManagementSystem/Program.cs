using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using UniversityEventsManagementSystem.Models;
using UniversityEventsManagementSystem.Repositories;
using UniversityEventsManagementSystem.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalDb3");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/SignIn");
		options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/SignIn");
	});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEventRepository, EventRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
