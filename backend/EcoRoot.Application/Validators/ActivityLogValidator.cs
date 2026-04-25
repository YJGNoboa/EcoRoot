using EcoRoot.Application.DTOs;
using FluentValidation;

namespace EcoRoot.Application.Validators
{
    public class ActivityLogCreateDtoValidator : AbstractValidator<ActivityLogCreateDto>
    {
        private static readonly string[] ValidActivityTypes =
        [
            "Irrigation", "Planting", "Harvesting", "Fertilization",
            "Pruning", "Monitoring", "Pest Control", "Other"
        ];

        public ActivityLogCreateDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.ActivityDate)
                .NotEmpty().WithMessage("Activity date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Activity date cannot be in the future.");

            RuleFor(x => x.ActivityType)
                .NotEmpty().WithMessage("Activity type is required.")
                .Must(t => ValidActivityTypes.Contains(t))
                .WithMessage($"Activity type must be one of: {string.Join(", ", ValidActivityTypes)}.");

            RuleFor(x => x.CropId)
                .GreaterThan(0).WithMessage("A valid crop must be selected.");

            RuleFor(x => x.StudentId)
                .GreaterThan(0).WithMessage("A valid student must be selected.");
        }
    }

    public class ActivityLogUpdateDtoValidator : AbstractValidator<ActivityLogUpdateDto>
    {
        private static readonly string[] ValidActivityTypes =
        [
            "Irrigation", "Planting", "Harvesting", "Fertilization",
            "Pruning", "Monitoring", "Pest Control", "Other"
        ];

        public ActivityLogUpdateDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.ActivityDate)
                .NotEmpty().WithMessage("Activity date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Activity date cannot be in the future.");

            RuleFor(x => x.ActivityType)
                .NotEmpty().WithMessage("Activity type is required.")
                .Must(t => ValidActivityTypes.Contains(t))
                .WithMessage($"Activity type must be one of: {string.Join(", ", ValidActivityTypes)}.");

            RuleFor(x => x.CropId)
                .GreaterThan(0).WithMessage("A valid crop must be selected.");

            RuleFor(x => x.StudentId)
                .GreaterThan(0).WithMessage("A valid student must be selected.");
        }
    }
}
