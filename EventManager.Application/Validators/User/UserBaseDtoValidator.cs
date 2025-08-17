using EventManager.Application.Models.User.Dtos;
using FluentValidation;

namespace EventManager.Application.Validators.User;

public class UserBaseDtoValidator : AbstractValidator<UserBaseDto>
{
    public UserBaseDtoValidator()
    {
        RuleFor(u=>u.FirstName)
            .NotNull().WithMessage("First name is required")
            .NotEmpty().WithMessage("First name cannot be empty")
            .Length(5,20).WithMessage("First name must be between 5 and 20 characters");
        RuleFor(u=>u.LastName)
            .NotNull().WithMessage("Last name is required")
            .NotEmpty().WithMessage("Last name cannot be empty")
            .Length(5,20).WithMessage("Last name must be between 5 and 20 characters");
    }
}