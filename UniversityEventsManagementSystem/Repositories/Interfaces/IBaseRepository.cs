using UniversityEventsManagementSystem.Models.Entity;

namespace UniversityEventsManagementSystem.Repositories.Interfaces;

public interface IBaseRepository<T>
{
	Task<List<T>> GetAll();
	Task<T> GetById(int id);
	Task Create(T entity);
	Task Remove(int id);
}
