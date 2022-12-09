using LibraryBookManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraryBookManagementSystem.Models.ViewModels;

public class AddBookViewModel
{
	[Required(ErrorMessage = "err")]
	public string Title { get; set; }
	[Required(ErrorMessage = "err")]
	public string Description { get; set; }
	[Required(ErrorMessage = "err")]
	public string Author { get; set; }
	public Genre Genre { get; set; }
}
