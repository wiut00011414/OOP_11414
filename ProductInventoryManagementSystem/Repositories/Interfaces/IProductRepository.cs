using ProductInventoryManagementSystem.Models.Entities;

namespace ProductInventoryManagementSystem.Repositories.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<List<Product>> SearchByValue(string value);
}
