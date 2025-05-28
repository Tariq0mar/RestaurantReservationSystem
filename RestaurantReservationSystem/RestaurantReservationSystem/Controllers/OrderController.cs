using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Order;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService,
        IMapper mapper)
    {
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orders));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderReadDto>> GetOrder(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null)
            return NotFound();

        return Ok(_mapper.Map<OrderReadDto>(order));
    }
}