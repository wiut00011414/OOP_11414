using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventoryManagementSystem.Factories;
using ProductInventoryManagementSystem.Models;
using ProductInventoryManagementSystem.Models.Entities;
using ProductInventoryManagementSystem.Models.ViewModels;
using ProductInventoryManagementSystem.Repositories;
using ProductInventoryManagementSystem.Repositories.Interfaces;
using System.Diagnostics;

namespace ProductInventoryManagementSystem.Controllers;

public class HomeController : Controller
{
	private readonly ProductRepository _repository;

	public HomeController(IProductRepository repository)
	{
		_repository = repository as ProductRepository;
	}

	public async Task<IActionResult> Index()
	{
		var products = await _repository.GetAll();
		return View(products);
	}

	public async Task<IActionResult> Search(string value)
	{
		var products = await _repository.SearchByValue(value);
		return View(products);
	}

	[HttpGet]
	public async Task<IActionResult> AddProduct() => View();

	[HttpPost]
	public async Task<IActionResult> AddProduct(AddProductViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		await _repository.Create(model);

		return RedirectToAction("Index");
	}

	[HttpGet]
	public async Task<IActionResult> EditProduct(int id)
	{
		var product = await _repository.GetById(id);
		var model = new EditProductViewModel
		{
			Id = product.Id,
			Name = product.Name,
			Description = product.Description,
			Price = product.Price,
			Count = product.Count,
			ProductType = product.ProductType
		};

		/*TO DO*/

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> EditProduct(EditProductViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		var product = await _repository.GetById(model.Id);


		return RedirectToAction("Index");
	}

	public async Task<IActionResult> RemoveProduct(int id)
	{
		await _repository.Remove(id);
		return RedirectToAction("Index");
	}

	public async Task<IActionResult> GetInfo(int id)
	{
		var product = await _repository.GetById(id);
		return Ok(product);
	}
}