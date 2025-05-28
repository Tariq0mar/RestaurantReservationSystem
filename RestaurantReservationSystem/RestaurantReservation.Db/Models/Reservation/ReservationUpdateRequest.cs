using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.Reservation;

public class RestaurantUpdateRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int RestaurantId { get; set; }

    [Required]
    public int TableId { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }

    [Required]
    public int PartySize { get; set; }
}