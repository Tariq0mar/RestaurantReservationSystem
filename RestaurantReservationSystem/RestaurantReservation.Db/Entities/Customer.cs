namespace RestaurantReservation.Db.Entities;

public class Customer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<Order> Orders { get; set; }
}