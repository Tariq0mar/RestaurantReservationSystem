namespace RestaurantReservation.Db.Entities;

public class Restaurant
{
    public int RestaurantId { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public ICollection<Table> Tables { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<MenuItem> MenuItems { get; set; }
}