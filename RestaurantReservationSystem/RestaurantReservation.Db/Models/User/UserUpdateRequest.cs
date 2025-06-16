using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.User;

public class UserUpdateRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Password { get; set; }
}