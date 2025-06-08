using FluentValidation;
using RestaurantReservation.Db.Models.Customer;

namespace RestaurantReservation.Db.Validators.CustomerValidators;

public class CustomerCreateRequestValidator : AbstractValidator<CustomerCreateRequest>
{
    public CustomerCreateRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .MaximumLength(50).WithMessage("FirstName cannot exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .MaximumLength(50).WithMessage("LastName cannot exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.")
            .MaximumLength(50).WithMessage("Email cannot exceed 50 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(50).WithMessage("PhoneNumber cannot exceed 50 characters.");
    }
}