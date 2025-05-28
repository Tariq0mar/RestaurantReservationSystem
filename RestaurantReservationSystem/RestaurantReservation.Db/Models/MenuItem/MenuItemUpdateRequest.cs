using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.MenuItem;

public class MenuItemUpdateRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int RestaurantId { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public decimal Price { get; set; }
}