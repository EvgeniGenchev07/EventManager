namespace EventManager.Application.Models.Event.Dtos;

public class EventBaseDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date{get;set;}
    public string Location { get; set; }
    public Core.Entities.Speaker Speaker { get; set; }
}