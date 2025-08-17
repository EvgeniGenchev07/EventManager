using EventManager.Application.Models.User.Dtos;
using FluentValidation;

namespace EventManager.Application.Validators.User;

public class UserUpdateDtoValidator :  AbstractValidator<UserUpdateDto>
{
    public UserUpdateDtoValidator(IValidator<UserBaseDto>  userBaseDtoValidator)
    {
        RuleFor(u => u.BirthOfDate)
            .LessThan(DateTime.Now).WithMessage("Birth of date must be before the current date");
        RuleFor(u=>u.NewPassword)
            .MinimumLength(8).WithMessage("New password must be at least 8 characters long");
        RuleFor(u => u.CurrentPassword)
            .MinimumLength(8).WithMessage("Current password must be at least 8 characters long");
        
        RuleFor(u=>u).SetValidator(userBaseDtoValidator);
    }
}