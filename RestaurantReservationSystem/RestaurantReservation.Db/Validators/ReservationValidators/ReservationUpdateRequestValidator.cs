using FluentValidation;
using RestaurantReservation.Db.Models.Reservation;

namespace RestaurantReservation.Db.Validators.ReservationValidators;

public class ReservationUpdateRequestValidator : AbstractValidator<ReservationUpdateRequest>
{
    public ReservationUpdateRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Reservation Id must be greater than 0.");

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("CustomerId is required.");

        RuleFor(x => x.RestaurantId)
            .GreaterThan(0).WithMessage("RestaurantId is required.");

        RuleFor(x => x.TableId)
            .GreaterThan(0).WithMessage("TableId is required.");

        RuleFor(x => x.ReservationDate)
            .GreaterThan(DateTime.Now).WithMessage("Reservation date must be in the future.");

        RuleFor(x => x.PartySize)
            .GreaterThan(0).WithMessage("Party size must be at least 1.");
    }
} 