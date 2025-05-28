using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.Table;

public class TableCreateRequest
{
    [Required]
    public int RestaurantId { get; set; }

    [Required]
    public int Capacity { get; set; }
}