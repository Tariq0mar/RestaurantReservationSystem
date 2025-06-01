using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.Restaurant;

public class RestaurantCreateRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? OpeningHours { get; set; }
}