using FluentValidation;
using School.core.Features.User.Commands.Models;

namespace School.core.Features.User.Commands.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage("Old Password is required");
            RuleFor(x => x.NewPassowrd).NotEmpty().WithMessage("New Password is required");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password is required");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassowrd).WithMessage("Confirm Password does not match");
        }
    }
}
