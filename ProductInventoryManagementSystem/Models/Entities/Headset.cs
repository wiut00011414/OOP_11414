using ProductInventoryManagementSystem.Models.Enums;

namespace ProductInventoryManagementSystem.Models.Entities;

public class Headset : Product
{
	public Headset(string name, string description, int price, int count)
	{
		Name = name;
		Description = description;
		Price = price;
		ProductType = ProductType.Headset;
		CreationDate = DateTime.Now;
		Count = count;
	}
}
