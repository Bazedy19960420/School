using FluentValidation;
using School.core.Features.User.Commands.Models;

namespace School.core.Features.User.Commands.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.ConfirmPassowrd).NotEmpty().WithMessage("Confirm Password is required");
            RuleFor(x => x.ConfirmPassowrd).Equal(x => x.Password).WithMessage("Password and Confirm Password must match");
        }
    }
}
