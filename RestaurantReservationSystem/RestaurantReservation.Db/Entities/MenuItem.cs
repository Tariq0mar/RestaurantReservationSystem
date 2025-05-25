namespace RestaurantReservation.Db.Entities;

public class MenuItem
{
    public int MenuItemId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}