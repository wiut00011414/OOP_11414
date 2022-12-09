using ProductInventoryManagementSystem.Models.Entities;
using ProductInventoryManagementSystem.Models.Enums;

namespace ProductInventoryManagementSystem.Factories;

public class PhoneFactory : Creator
{
	private string _name;
	private string _description;
	private int _price;
	private int _count;

	public PhoneFactory(string name, string description, int price, int count)
	{
		_name = name;
		_description = description;
		_price = price;
		_count = count;
	}

	public override Product Create() => new Phone(_name, _description, _price,_count);
}
