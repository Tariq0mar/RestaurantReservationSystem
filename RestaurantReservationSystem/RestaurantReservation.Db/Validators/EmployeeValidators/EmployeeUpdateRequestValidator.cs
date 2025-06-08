using FluentValidation;
using RestaurantReservation.Db.Models.Employee;

namespace RestaurantReservation.Db.Validators.EmployeeValidators;

public class EmployeeUpdateRequestValidator : AbstractValidator<EmployeeUpdateRequest>
{
    public EmployeeUpdateRequestValidator()
    {
        RuleFor(x => x.RestaurantId)
            .GreaterThan(0).WithMessage("RestaurantId must be greater than 0.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
    }
}