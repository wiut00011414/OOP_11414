namespace UniversityEventsManagementSystem.Models.Entity;

public class Event
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Creator { get; set; }
	public DateTime CreationDate { get; set; }
	public DateTime ExpiryDate { get; set;}
}
