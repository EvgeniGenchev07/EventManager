using EventManager.Application.Models.User.Dtos;
using EventManager.Core.Enumerators;
using FluentValidation;

namespace EventManager.Application.Validators.User;

public class UserCreateDtoValidator  : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator(IValidator<UserBaseDto>  userBaseDtoValidator)
    {
        RuleFor(u => u.Email)
            .NotNull().WithMessage("Email is required")
            .NotEmpty().WithMessage("Email cannot be empty")
            .EmailAddress().WithMessage("Email is not valid");
        RuleFor(u=>u.Role)
            .NotNull().WithMessage("Role is required")
            .NotEmpty().WithMessage("Role cannot be empty")
            .IsInEnum().WithMessage("Role is not valid");
        RuleFor(u => u.Password)
            .NotNull().WithMessage("Password is required")
            .NotEmpty().WithMessage("Password cannot be empty")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");
        
        RuleFor(u=>u).SetValidator(userBaseDtoValidator);
    }
}