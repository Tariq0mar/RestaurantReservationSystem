using FluentValidation;
using RestaurantReservation.Db.Models.MenuItem;

namespace RestaurantReservation.Db.Validators.MenuItemValidators;

public class MenuItemUpdateRequestValidator : AbstractValidator<MenuItemUpdateRequest>
{
    public MenuItemUpdateRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(x => x.RestaurantId)
            .GreaterThan(0).WithMessage("RestaurantId must be greater than 0.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.Description)
            .MaximumLength(300).WithMessage("Description cannot exceed 300 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}