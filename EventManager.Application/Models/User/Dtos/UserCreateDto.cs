using EventManager.Core.Enumerators;

namespace EventManager.Application.Models.User.Dtos;

public class UserCreateDto : UserBaseDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    
}