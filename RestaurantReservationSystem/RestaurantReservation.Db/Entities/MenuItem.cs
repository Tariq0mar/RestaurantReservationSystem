using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

public class MenuItem
{
    [Key]
    public int ItemId { get; set; }

    [ForeignKey(nameof(Restaurant))]
    public int RestaurantId { get; set; }


    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }


    public Restaurant Restaurant { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}