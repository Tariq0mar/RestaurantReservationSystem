namespace RestaurantReservation.Db.Entities;

public class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; }

    public string Role { get; set; }

    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}