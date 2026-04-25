using EcoRoot.Application.DTOs;
using FluentValidation;

namespace EcoRoot.Application.Validators
{
    public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.")
                .Matches(@"^[\p{L}\s\-']+$").WithMessage("First name can only contain letters, spaces, hyphens, and apostrophes.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters.")
                .Matches(@"^[\p{L}\s\-']+$").WithMessage("Last name can only contain letters, spaces, hyphens, and apostrophes.");

            RuleFor(x => x.Grade)
                .NotEmpty().WithMessage("Grade is required.")
                .MaximumLength(20).WithMessage("Grade cannot exceed 20 characters.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email address is not valid.")
                .MaximumLength(150).WithMessage("Email cannot exceed 150 characters.")
                .When(x => !string.IsNullOrEmpty(x.Email));
        }
    }

    public class StudentUpdateDtoValidator : AbstractValidator<StudentUpdateDto>
    {
        public StudentUpdateDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.")
                .Matches(@"^[\p{L}\s\-']+$").WithMessage("First name can only contain letters, spaces, hyphens, and apostrophes.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters.")
                .Matches(@"^[\p{L}\s\-']+$").WithMessage("Last name can only contain letters, spaces, hyphens, and apostrophes.");

            RuleFor(x => x.Grade)
                .NotEmpty().WithMessage("Grade is required.")
                .MaximumLength(20).WithMessage("Grade cannot exceed 20 characters.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email address is not valid.")
                .MaximumLength(150).WithMessage("Email cannot exceed 150 characters.")
                .When(x => !string.IsNullOrEmpty(x.Email));
        }
    }
}
