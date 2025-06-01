using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.OrderItem;

public class OrderItemUpdateRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int ItemId { get; set; }

    [Required]
    public int Quantity { get; set; }
}