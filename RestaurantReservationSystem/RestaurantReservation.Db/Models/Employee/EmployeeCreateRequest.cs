using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.Employee;

public class EmployeeCreateRequest
{
    [Required]
    public int RestaurantId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string? Position { get; set; }
}