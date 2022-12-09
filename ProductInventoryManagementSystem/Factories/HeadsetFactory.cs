﻿using ProductInventoryManagementSystem.Models.Entities;
using ProductInventoryManagementSystem.Models.Enums;

namespace ProductInventoryManagementSystem.Factories;

public class HeadsetFactory : Creator
{
	private string _name;
	private string _description;
	private int _price;
	private int _count;

	public HeadsetFactory(string name, string description, int price, int count)
	{
		_name = name;
		_description = description;
		_price = price;
		_count = count;
	}

	public override Product Create() => new Headset(_name, _description, _price,_count);

}
