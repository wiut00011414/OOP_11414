using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityEventsManagementSystem.Models;
using UniversityEventsManagementSystem.Models.Entity;
using UniversityEventsManagementSystem.Repositories.Interfaces;

namespace UniversityEventsManagementSystem.Controllers;

[Authorize]
public class HomeController : Controller
{
	private readonly IEventRepository _repository;
	public HomeController(IEventRepository repository)
	{
		_repository = repository;
	}
	
	public async Task<IActionResult> Index() => View(await _repository.GetAll());

	[HttpGet]
	public IActionResult Create() => View();

	[HttpPost]
	public async Task<IActionResult> Create(Event model)
	{
		await _repository.Create(model);

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> Remove(int id)
	{
		await _repository.Remove(id);

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> GetInfo(int id) => Ok(await _repository.GetById(id));
}