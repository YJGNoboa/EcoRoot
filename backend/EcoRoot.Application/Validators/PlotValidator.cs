using EcoRoot.Application.DTOs;
using FluentValidation;

namespace EcoRoot.Application.Validators
{
    public class PlotCreateDtoValidator : AbstractValidator<PlotCreateDto>
    {
        public PlotCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Area)
                .GreaterThan(0).WithMessage("Area must be greater than 0.")
                .LessThanOrEqualTo(100_000).WithMessage("Area cannot exceed 100,000 m².");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(200).WithMessage("Location cannot exceed 200 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .When(x => x.Description is not null);
        }
    }

    public class PlotUpdateDtoValidator : AbstractValidator<PlotUpdateDto>
    {
        public PlotUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Area)
                .GreaterThan(0).WithMessage("Area must be greater than 0.")
                .LessThanOrEqualTo(100_000).WithMessage("Area cannot exceed 100,000 m².");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(200).WithMessage("Location cannot exceed 200 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .When(x => x.Description is not null);
        }
    }
}
