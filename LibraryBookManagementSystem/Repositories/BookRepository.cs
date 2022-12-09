using LibraryBookManagementSystem.Models;
using LibraryBookManagementSystem.Models.Entities;
using LibraryBookManagementSystem.Models.ViewModels;
using LibraryBookManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryBookManagementSystem.Repositories;

public class BookRepository : IBookRepository
{
	private readonly ApplicationDbContext db;
	public BookRepository(ApplicationDbContext context)
	{
		db = context;
	}

	public async Task Create(Book entity)
	{
		await db.Books.AddAsync(entity);
		await db.SaveChangesAsync();
	}

	public async Task<List<Book>> GetAll()
	{
		var books = await db.Books.ToListAsync();
		return books;
	}

	public async Task<Book> GetById(int id)
	{
		var book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
		return book;
	}

	public async Task Remove(int id)
	{
		var book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
		db.Books.Remove(book);
		await db.SaveChangesAsync();
	}

	public async Task<List<Book>> SearchByValue(string value)
	{
		var result = await db.Books.Where(b => b.Title.Contains(value) || b.Description.Contains(value) || b.Author.Contains(value)).ToListAsync();
		return result;
	}

	public async Task Update(Book entity)
	{
		db.Books.Update(entity);
		await db.SaveChangesAsync();
	}
}
