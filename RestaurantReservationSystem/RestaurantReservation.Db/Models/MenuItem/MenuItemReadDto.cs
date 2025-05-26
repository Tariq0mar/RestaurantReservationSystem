namespace RestaurantReservation.Db.Models.MenuItem;

public class MenuItemReadDto
{
    public int ItemId { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}


