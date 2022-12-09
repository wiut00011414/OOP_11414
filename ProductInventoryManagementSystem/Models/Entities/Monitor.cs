using ProductInventoryManagementSystem.Models.Enums;

namespace ProductInventoryManagementSystem.Models.Entities;

public class Monitor : Product
{
	public Monitor(string name, string description, int price, int count)
	{
		Name = name;
		Description = description;
		Price = price;
		ProductType = ProductType.Monitor;
		CreationDate = DateTime.Now;
		Count = count;
	}
}
