
namespace EventManager.Application.Models.Speaker.Dtos;

public class SpeakerBaseDto
{
    public string Name { get; set; }
    public string Biography { get; set; }
    public ICollection<Core.Entities.Event> Events { get; set; }
}