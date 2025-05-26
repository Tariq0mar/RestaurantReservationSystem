using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Models.Order;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly RestaurantReservationDbContext _context;
    private readonly IMapper _mapper;

    public OrderController(RestaurantReservationDbContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders()
    {
        var orderEntities = await _context.Orders.ToListAsync();

        return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orderEntities));
    }
}