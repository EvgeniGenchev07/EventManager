namespace EventManager.Application.Models.Registration.Dtos;

public class RegistrationBaseDto
{
    public DateTime RegistrationDate { get; set; }
    public Core.Entities.Event Event { get; set; }
    public Core.Entities.User User { get; set; }
}