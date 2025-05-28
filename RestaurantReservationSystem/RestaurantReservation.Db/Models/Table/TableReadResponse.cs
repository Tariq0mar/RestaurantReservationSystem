namespace RestaurantReservation.Db.Models.Table;

public class TableReadResponse
{
    public int TableId { get; set; }
    public int RestaurantId { get; set; }
    public int Capacity { get; set; }
}