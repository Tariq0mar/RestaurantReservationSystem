using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.Reservation;

public class ReservationCreateRequest
{
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