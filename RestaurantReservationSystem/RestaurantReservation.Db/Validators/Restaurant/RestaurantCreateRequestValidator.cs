using FluentValidation;
using RestaurantReservation.Db.Models.Restaurant;

namespace RestaurantReservation.Db.Validators.Restaurant;

public class RestaurantCreateRequestValidator : AbstractValidator<RestaurantCreateRequest>
{
    public RestaurantCreateRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Address is required.");

        RuleFor(x => x.OpeningHours)
            .MaximumLength(100).WithMessage("Opening hours cannot exceed 100 characters.")
            .When(x => !string.IsNullOrEmpty(x.OpeningHours));
    }
}