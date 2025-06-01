using FluentValidation;
using RestaurantReservation.Db.Models.Order;

namespace RestaurantReservation.Db.Validators.OrderValidators;

public class OrderUpdateRequestValidator : AbstractValidator<OrderUpdateRequest>
{
    public OrderUpdateRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(x => x.ReservationId)
            .GreaterThan(0).WithMessage("ReservationId must be greater than 0.");

        RuleFor(x => x.EmployeeId)
            .GreaterThan(0).WithMessage("EmployeeId must be greater than 0.");

        RuleFor(x => x.OrderDate)
            .NotEmpty().WithMessage("OrderDate is required.");

        RuleFor(x => x.TotalAmount)
            .GreaterThanOrEqualTo(0).WithMessage("TotalAmount must be a non-negative value.");
    }
}