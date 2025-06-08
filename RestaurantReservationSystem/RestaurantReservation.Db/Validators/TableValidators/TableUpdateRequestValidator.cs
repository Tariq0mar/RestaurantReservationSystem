using FluentValidation;
using RestaurantReservation.Db.Models.Table;

namespace RestaurantReservation.Db.Validators.TableValidators;

public class TableUpdateRequestValidator : AbstractValidator<TableUpdateRequest>
{
    public TableUpdateRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Table Id must be greater than 0.");

        RuleFor(x => x.RestaurantId)
            .GreaterThan(0).WithMessage("RestaurantId is required.");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("Capacity must be at least 1.");
    }
}