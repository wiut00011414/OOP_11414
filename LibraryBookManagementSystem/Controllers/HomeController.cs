using LibraryBookManagementSystem.Models;
using LibraryBookManagementSystem.Models.Entities;
using LibraryBookManagementSystem.Models.ViewModels;
using LibraryBookManagementSystem.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryBookManagementSystem.Repositories.Interfaces;
using LibraryBookManagementSystem.Repositories;

namespace LibraryBookManagementSystem.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly IBookRepository _repository;
    public HomeController(IBookRepository context)
    {
		_repository = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var books = await _repository.GetAll();
        return View(books);
    }

    public async Task<IActionResult> Search(string value)
    {
        var result = await _repository.SearchByValue(value);
        return View(result);
    }

    [HttpGet]
	[Authorize(Roles = "librarian, admin")]
	public IActionResult AddBook() => View();

    [HttpPost]
	[Authorize(Roles = "librarian, admin")]
	public async Task<IActionResult> AddBook(AddBookViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var book = new Book
        {
            Title = model.Title,
            Author = model.Author,
            Description = model.Description,
            Genre = model.Genre
        };

        await _repository.Create(book);

        return RedirectToAction("Index");
    }

    [HttpGet]
    [Authorize(Roles = "librarian, admin")]
    public async Task<IActionResult> EditBook(int id)
    {
        var book = await _repository.GetById(id);
        var model = new EditBookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Description = book.Description,
            Genre = book.Genre
        };
        return View(model);
    }

    [HttpPost]
	[Authorize(Roles = "librarian, admin")]
	public async Task<IActionResult> EditBook(EditBookViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var book = await _repository.GetById(model.Id);
        book.Title = model.Title;
        book.Author = model.Author;
        book.Description = model.Description;
        book.Genre = model.Genre;

        await _repository.Update(book);

        return RedirectToAction("Index");
    }

    [HttpGet]
	[Authorize(Roles = "librarian, admin")]
	public async Task<IActionResult> RemoveBook(int id)
    {
        var book = await _repository.GetById(id);
        await _repository.Remove(id);
        return RedirectToAction("Index");
    }

	public async Task<IActionResult> GetInfo(int id)
	{
		var book = await _repository.GetById(id);
		return Ok(book);
	}
}