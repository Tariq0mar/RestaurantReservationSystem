using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Reservation;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/reservations")]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public ReservationController(IReservationService reservationService,
        IMapper mapper)
    {
        _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationReadResponse>>> GetReservations()
    {
        var reservations = await _reservationService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ReservationReadResponse>>(reservations));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationReadResponse>> GetReservation(int id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);
        if (reservation == null)
            return NotFound();

        return Ok(_mapper.Map<ReservationReadResponse>(reservation));
    }
}