namespace RestaurantReservation.Db.Entities;

public class Reservation
{
    public int ReservationId { get; set; }

    public DateTime ReservationTime { get; set; }

    public int NumberOfGuests { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int TableId { get; set; }
    public Table Table { get; set; }
}