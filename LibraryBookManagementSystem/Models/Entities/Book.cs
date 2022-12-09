using LibraryBookManagementSystem.Models.Enums;

namespace LibraryBookManagementSystem.Models.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public Genre Genre { get; set; }
}
