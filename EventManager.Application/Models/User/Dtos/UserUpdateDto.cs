namespace EventManager.Application.Models.User.Dtos;

public class UserUpdateDto : UserBaseDto
{
    public string Id { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public DateTime BirthOfDate { get; set; }
    
}