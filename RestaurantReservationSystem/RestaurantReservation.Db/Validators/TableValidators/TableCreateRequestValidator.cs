using FluentValidation;
using RestaurantReservation.Db.Models.Table;

namespace RestaurantReservation.Db.Validators.TableValidators;

public class TableCreateRequestValidator : AbstractValidator<TableCreateRequest>
{
    public TableCreateRequestValidator()
    {
        RuleFor(x => x.RestaurantId)
            .GreaterThan(0).WithMessage("RestaurantId is required.");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("Capacity must be at least 1.");
    }
}