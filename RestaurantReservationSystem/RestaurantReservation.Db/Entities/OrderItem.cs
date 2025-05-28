using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

public class OrderItem
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }

    [ForeignKey(nameof(MenuItem))]
    public int ItemId { get; set; }

    [Required]
    public int Quantity { get; set; }

    public Order Order { get; set; }
    public MenuItem MenuItem { get; set; }
}