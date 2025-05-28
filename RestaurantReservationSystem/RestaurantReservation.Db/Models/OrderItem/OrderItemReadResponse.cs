namespace RestaurantReservation.Db.Models.OrderItem;

public class OrderItemReadResponse
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}