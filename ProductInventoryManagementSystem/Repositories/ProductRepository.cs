using Microsoft.EntityFrameworkCore;
using ProductInventoryManagementSystem.Factories;
using ProductInventoryManagementSystem.Models;
using ProductInventoryManagementSystem.Models.Entities;
using ProductInventoryManagementSystem.Models.ViewModels;
using ProductInventoryManagementSystem.Repositories.Interfaces;

namespace ProductInventoryManagementSystem.Repositories;

public class ProductRepository : IProductRepository
{
	private readonly ApplicationDbContext db;

	public ProductRepository(ApplicationDbContext context)
	{
		db = context;
	}

	public async Task Create(Product entity)
	{
		throw new NotImplementedException();
	}

	public async Task Create(AddProductViewModel entity)
	{
		Product product;
		switch (entity.ProductType)
		{
			case Models.Enums.ProductType.Phone:
				product = new PhoneFactory(entity.Name, entity.Description, entity.Price, entity.Count).Create();
				await db.Products.AddAsync(product);
				break;
			case Models.Enums.ProductType.Device:
				product = new DeviceFactory(entity.Name, entity.Description, entity.Price, entity.Count).Create();
				await db.Products.AddAsync(product);
				break;
			case Models.Enums.ProductType.Monitor:
				product = new MonitorFactory(entity.Name, entity.Description, entity.Price, entity.Count).Create();
				await db.Products.AddAsync(product);
				break;
			case Models.Enums.ProductType.Headset:
				product = new HeadsetFactory(entity.Name, entity.Description, entity.Price, entity.Count).Create();
				await db.Products.AddAsync(product);
				break;
			case Models.Enums.ProductType.Other:
				product = new OtherProductFactory(entity.Name, entity.Description, entity.Price, entity.Count).Create();
				await db.Products.AddAsync(product);
				break;
			default:
				break;
		}

		await db.SaveChangesAsync();
	}

	public async Task<List<Product>> GetAll()
	{
		var products = await db.Products.ToListAsync();
		return products;
	}

	public async Task<Product> GetById(int id)
	{
		var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
		return product;
	}

	public async Task Remove(int id)
	{
		var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
		db.Products.Remove(product);
		await db.SaveChangesAsync();
	}

    public async Task<List<Product>> SearchByValue(string value)
    {
        var result = await db.Products.Where(p => p.Name.Contains(value)).ToListAsync();
        return result;
    }

    public Task Update(Product entity)
	{
		throw new NotImplementedException();
	}

	public async Task Update(EditProductViewModel model)
	{

	}

}
