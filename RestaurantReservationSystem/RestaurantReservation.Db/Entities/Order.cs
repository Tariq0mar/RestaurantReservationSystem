using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [ForeignKey(nameof(Reservation))]
    public int ReservationId { get; set; }

    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }


    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public decimal TotalAmount { get; set; }


    public Reservation Reservation { get; set; }
    public Employee Employee { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}