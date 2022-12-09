using ProductInventoryManagementSystem.Models.Enums;

namespace ProductInventoryManagementSystem.Models.Entities;

public abstract class Product
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public int Price { get; set; }
	public int Count { get; set; }
	public DateTime? CreationDate { get; set; }
	public ProductType ProductType { get; set; }
}
