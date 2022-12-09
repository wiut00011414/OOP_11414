using ProductInventoryManagementSystem.Models.Enums;

namespace ProductInventoryManagementSystem.Models.Entities;

public class Phone : Product
{
	public Phone(string name, string description, int price, int count)
	{
		Name = name;
		Description = description;
		Price = price;
		ProductType = ProductType.Phone;
		CreationDate = DateTime.Now;
		Count = count;
	}
}
