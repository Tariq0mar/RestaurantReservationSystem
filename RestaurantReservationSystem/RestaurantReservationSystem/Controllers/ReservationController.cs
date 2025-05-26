using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Models.Order;
using RestaurantReservation.Db.Models.OrderItem;
using RestaurantReservation.Db.Models.Reservation;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/reservations")]
public class ReservationController : ControllerBase
{
    private readonly RestaurantReservationDbContext _context;
    private readonly IMapper _mapper;

    public ReservationController(RestaurantReservationDbContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetReservations()
    {
        var reservationEntities = await _context.Reservations.ToListAsync();

        return Ok(_mapper.Map<IEnumerable<ReservationReadDto>>(reservationEntities));
    }
}