using EventManager.Core.Enumerators;

namespace EventManager.Application.Models.User.Dtos;

public class UserGetDto : UserBaseDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public DateTime BirthOfDate { get; set; }
    
}