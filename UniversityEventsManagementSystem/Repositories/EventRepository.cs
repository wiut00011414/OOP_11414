using Microsoft.EntityFrameworkCore;
using UniversityEventsManagementSystem.Models;
using UniversityEventsManagementSystem.Models.Entity;
using UniversityEventsManagementSystem.Repositories.Interfaces;

namespace UniversityEventsManagementSystem.Repositories;

public class EventRepository : IEventRepository
{
	private readonly ApplicationDbContext db;
	public EventRepository(ApplicationDbContext conext)
	{
		db = conext;
	}

	public async Task Create(Event entity)
	{
		entity.CreationDate = DateTime.Now;
		await db.Events.AddAsync(entity);
		await db.SaveChangesAsync();
	}

	public async Task<List<Event>> GetAll() => await db.Events.ToListAsync();

	public async Task<Event> GetById(int id) => await db.Events.FirstOrDefaultAsync(e => e.Id == id);

	public async Task Remove(int id)
	{
		var result = await db.Events.FirstOrDefaultAsync(e => e.Id == id);
		db.Remove(result);
		await db.SaveChangesAsync();
	}
}
