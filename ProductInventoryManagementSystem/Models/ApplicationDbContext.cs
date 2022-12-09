using Microsoft.EntityFrameworkCore;
using ProductInventoryManagementSystem.Models.Entities;

namespace ProductInventoryManagementSystem.Models;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
		: base(options)
	{
		Database.EnsureCreated();
	}

	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<Phone>();
		builder.Entity<Device>();
		builder.Entity<Headset>();
		builder.Entity<Entities.Monitor>();
		builder.Entity<OtherProduct>();
		
		base.OnModelCreating(builder);
	}
}
