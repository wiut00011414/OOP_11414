using ProductInventoryManagementSystem.Models.Enums;

namespace ProductInventoryManagementSystem.Models.Entities;

public class OtherProduct : Product
{
	public OtherProduct(string name, string description, int price, int count)
	{
		Name = name;
		Description = description;
		Price = price;
		ProductType = ProductType.Other;
		CreationDate = DateTime.Now;
		Count = count;
	}
}
