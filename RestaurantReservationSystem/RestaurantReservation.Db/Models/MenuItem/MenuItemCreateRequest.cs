using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.MenuItem;

public class MenuItemCreateRequest
{
    [Required]
    public int RestaurantId { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public decimal Price { get; set; }
}