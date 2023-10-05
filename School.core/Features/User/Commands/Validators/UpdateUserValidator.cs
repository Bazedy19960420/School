using FluentValidation;
using School.core.Features.User.Commands.Models;

namespace School.core.Features.User.Commands.Validators
{
    public class UpdateUserValidator : AbstractValidator<AddUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name is required");
        }
    }
}
