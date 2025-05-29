using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Customer;
using RestaurantReservation.Db.Models.Order;
using RestaurantReservation.Db.Services;

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
    public async Task<ActionResult<IEnumerable<OrderReadResponse>>> GetOrders()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<OrderReadResponse>>(orders));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderReadResponse>> GetOrder(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null)
            return NotFound();

        return Ok(_mapper.Map<OrderReadResponse>(order));
    }

    [HttpPost]
    public async Task<ActionResult<OrderReadResponse>> CreateOrder([FromBody] OrderCreateRequest request)
    {
        var order = _mapper.Map<Order>(request);

        await _orderService.AddAsync(order);

        var response = _mapper.Map<OrderReadResponse>(order);

        return Ok(response);
    }
}