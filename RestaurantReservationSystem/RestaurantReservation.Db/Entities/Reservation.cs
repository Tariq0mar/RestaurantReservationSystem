using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

public class Reservation
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(Restaurant))]
    public int RestaurantId { get; set; }

    [ForeignKey(nameof(Table))]
    public int TableId { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }

    [Required]
    public int PartySize { get; set; }

    public Customer Customer { get; set; }
    public Restaurant Restaurant { get; set; }
    public Table Table { get; set; }
    public ICollection<Order> Orders { get; set; }
}