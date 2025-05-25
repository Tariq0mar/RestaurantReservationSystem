namespace RestaurantReservation.Db.Entities;

public class OrderItem
{
    public int OrderItemId { get; set; }

    public int Quantity { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
}