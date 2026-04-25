using EcoRoot.Application.DTOs;
using FluentValidation;

namespace EcoRoot.Application.Validators
{
    public class CropCreateDtoValidator : AbstractValidator<CropCreateDto>
    {
        private static readonly string[] ValidStatuses = ["Active", "Harvested", "Lost", "Pending"];

        public CropCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required.")
                .MaximumLength(50).WithMessage("Type cannot exceed 50 characters.");

            RuleFor(x => x.PlantingDate)
                .NotEmpty().WithMessage("Planting date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Planting date cannot be in the future.");

            RuleFor(x => x.EstimatedHarvestDate)
                .GreaterThan(x => x.PlantingDate)
                .WithMessage("Estimated harvest date must be after the planting date.")
                .When(x => x.EstimatedHarvestDate.HasValue);

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(s => ValidStatuses.Contains(s))
                .WithMessage($"Status must be one of: {string.Join(", ", ValidStatuses)}.");

            RuleFor(x => x.PlotId)
                .GreaterThan(0).WithMessage("A valid plot must be selected.");
        }
    }

    public class CropUpdateDtoValidator : AbstractValidator<CropUpdateDto>
    {
        private static readonly string[] ValidStatuses = ["Active", "Harvested", "Lost", "Pending"];

        public CropUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required.")
                .MaximumLength(50).WithMessage("Type cannot exceed 50 characters.");

            RuleFor(x => x.PlantingDate)
                .NotEmpty().WithMessage("Planting date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Planting date cannot be in the future.");

            RuleFor(x => x.EstimatedHarvestDate)
                .GreaterThan(x => x.PlantingDate)
                .WithMessage("Estimated harvest date must be after the planting date.")
                .When(x => x.EstimatedHarvestDate.HasValue);

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(s => ValidStatuses.Contains(s))
                .WithMessage($"Status must be one of: {string.Join(", ", ValidStatuses)}.");

            RuleFor(x => x.PlotId)
                .GreaterThan(0).WithMessage("A valid plot must be selected.");
        }
    }
}
