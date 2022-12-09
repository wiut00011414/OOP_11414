using ProductInventoryManagementSystem.Models.Entities;
using ProductInventoryManagementSystem.Models.Enums;

namespace ProductInventoryManagementSystem.Factories;

public class DeviceFactory : Creator
{
	private string _name;
	private string _description;
	private int _price;
	private int _count;

	public DeviceFactory(string name, string description, int price, int count)
	{
		_name = name;
		_description = description;
		_price = price;
		_count = count;
	}

	public override Product Create() => new Device(_name, _description, _price, _count);
}
