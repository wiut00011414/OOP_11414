using LibraryBookManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LibraryBookManagementSystem.Models;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
}
