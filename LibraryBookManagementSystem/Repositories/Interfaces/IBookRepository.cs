using LibraryBookManagementSystem.Models.Entities;

namespace LibraryBookManagementSystem.Repositories.Interfaces;

public interface IBookRepository : IBaseRepository<Book>
{
	Task<List<Book>> SearchByValue(string value);
}
