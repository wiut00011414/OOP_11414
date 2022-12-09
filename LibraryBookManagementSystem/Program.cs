using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using LibraryBookManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using LibraryBookManagementSystem.Repositories.Interfaces;
using LibraryBookManagementSystem.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalDb");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });

builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
