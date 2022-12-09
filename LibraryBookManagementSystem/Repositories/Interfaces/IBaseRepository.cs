using LibraryBookManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace LibraryBookManagementSystem.Repositories.Interfaces;

public interface IBaseRepository<T>
{
	Task<List<T>> GetAll();
	Task<T> GetById(int id);
	Task Create(T entity);
	Task Remove(int id);
	Task Update(T entity);
}
