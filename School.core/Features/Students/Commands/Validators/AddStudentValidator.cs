using FluentValidation;
using School.core.Features.Students.Commands.Models;
using School.service.Abstracts;

namespace School.core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Feilds
        private readonly IStudentService _studentService;
        #endregion
        #region Constructors
        public AddStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRule();
            ApplyCustomValidationRule();
        }
        #endregion
        #region Methods

        public void ApplyValidationRule()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
            .MaximumLength(10).WithMessage("Name must be less than 10 characters")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .NotNull().WithMessage("Name is required");

            RuleFor(x => x.Address).NotEmpty().WithMessage("{{PropertyName}} is required")
            .MaximumLength(100).WithMessage("{{PropertyName}} must be less than 100 characters")
            .NotNull().WithMessage("{{PropertyName}} is required");

        }
        public void ApplyCustomValidationRule()
        {
            RuleFor(x => x.Name).MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key)).WithMessage("Name is already exist");
        }
        #endregion
    }
}
