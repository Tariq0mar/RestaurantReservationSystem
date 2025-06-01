using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.Order;

public class OrderUpdateRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int ReservationId { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public decimal TotalAmount { get; set; }
}