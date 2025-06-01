using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models.Customer;

public class CustomerCreateRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PhoneNumber { get; set; }
}

