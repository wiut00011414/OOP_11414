using Microsoft.EntityFrameworkCore;
using ProductInventoryManagementSystem.Models;
using ProductInventoryManagementSystem.Repositories;
using ProductInventoryManagementSystem.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalDb2");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
