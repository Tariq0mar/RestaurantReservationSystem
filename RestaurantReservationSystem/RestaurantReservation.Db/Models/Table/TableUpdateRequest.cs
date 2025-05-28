using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.Table;

public class TableUpdateRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int RestaurantId { get; set; }

    [Required]
    public int Capacity { get; set; }
}