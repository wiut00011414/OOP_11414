using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using UniversityEventsManagementSystem.Models.Entity;

namespace UniversityEventsManagementSystem.Models;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
		: base(options)
	{
		Database.EnsureCreated();
	}

	public DbSet<Event> Events { get; set; }
}
