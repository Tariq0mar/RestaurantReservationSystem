using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.User;

public class UserCreateRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Password { get; set; }
}