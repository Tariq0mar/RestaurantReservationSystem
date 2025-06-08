namespace RestaurantReservation.Db.Models.User;

public class UserAuthenticationRequest
{
    public string? Name { get; set; }
    public string? Password { get; set; }
}