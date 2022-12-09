using ProductInventoryManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProductInventoryManagementSystem.Models.ViewModels;

public class AddProductViewModel
{
    [Required(ErrorMessage = "name can`t be empty")]
    public string Name { get; set; }
	[Required(ErrorMessage = "description can`t be empty")]
	public string Description { get; set; }
	[Required(ErrorMessage = "price can`t be empty")]
	public int Price { get; set; }
	[Required(ErrorMessage = "count can`t be empty")]
	public int Count { get; set; }
    public ProductType ProductType { get; set; }
}
