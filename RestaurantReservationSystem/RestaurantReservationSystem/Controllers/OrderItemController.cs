using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Models.OrderItem;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/orderItems")]
public class OrderItemController : ControllerBase
{
    private readonly RestaurantReservationDbContext _context;
    private readonly IMapper _mapper;

    public OrderItemController(RestaurantReservationDbContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderItemReadDto>>> GetOrderItems()
    {
        var orderItemsEntities = await _context.OrderItems.ToListAsync();

        return Ok(_mapper.Map<IEnumerable<OrderItemReadDto>>(orderItemsEntities));
    }
}