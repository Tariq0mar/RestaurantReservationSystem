using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; } = string.Empty;
}