using ProductInventoryManagementSystem.Models.Enums;

namespace ProductInventoryManagementSystem.Models.Entities;

public class Device : Product
{
	public Device(string name, string description, int price, int count)
	{
		Name = name;
		Description = description;
		Price = price;
		ProductType = ProductType.Device;
		CreationDate = DateTime.Now;
		Count = count;
	}
}
