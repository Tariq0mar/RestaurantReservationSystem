using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Customer;
using RestaurantReservation.Db.Models.Reservation;
using RestaurantReservation.Db.Services;

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

    [HttpPost]
    public async Task<ActionResult<ReservationReadResponse>> CreateReservation([FromBody] ReservationCreateRequest request)
    {
        var reservation = _mapper.Map<Reservation>(request);

        await _reservationService.AddAsync(reservation);

        var response = _mapper.Map<ReservationReadResponse>(reservation);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateReservation(int id, [FromBody] ReservationUpdateRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest("ID in URL and request body must match.");
        }

        var existingReservation = await _reservationService.GetByIdAsync(id);
        if (existingReservation is null)
        {
            return NotFound();
        }

        _mapper.Map(request, existingReservation);

        await _reservationService.UpdateAsync(existingReservation);

        return NoContent();
    }
}