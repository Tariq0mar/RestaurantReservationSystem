namespace RestaurantReservation.Db.Models.Reservation;

public class ReservationReadDto
{
    public int ReservationId { get; set; }
    public int CustomerId { get; set; }

    public int RestaurantId { get; set; }

    public int TableId { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
}