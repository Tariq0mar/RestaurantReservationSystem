using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

public class Table
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Restaurant))]
    public int RestaurantId { get; set; }

    [Required]
    public int Capacity { get; set; }

<<<<<<< HEAD

=======
>>>>>>> Dev
    public Restaurant Restaurant { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
