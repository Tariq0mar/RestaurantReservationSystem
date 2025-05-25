namespace RestaurantReservation.Db.Entities;

public class Order
{
    public int OrderId { get; set; }

    public DateTime OrderTime { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}