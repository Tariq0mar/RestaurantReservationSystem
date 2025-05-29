using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Customer;
using RestaurantReservation.Db.Models.OrderItem;
using RestaurantReservation.Db.Services;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/order-items")]
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;
    private readonly IMapper _mapper;

    public OrderItemController(IOrderItemService orderItemService,
        IMapper mapper)
    {
        _orderItemService = orderItemService ?? throw new ArgumentNullException(nameof(orderItemService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderItemReadResponse>>> GetOrderItems()
    {
        var orderItems = await _orderItemService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<OrderItemReadResponse>>(orderItems));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderItemReadResponse>> GetOrderItem(int id)
    {
        var orderItem = await _orderItemService.GetByIdAsync(id);
        if (orderItem == null)
            return NotFound();

        return Ok(_mapper.Map<OrderItemReadResponse>(orderItem));
    }

    [HttpPost]
    public async Task<ActionResult<OrderItemReadResponse>> CreateOrderItem([FromBody] OrderItemCreateRequest request)
    {
        var orderItem= _mapper.Map<OrderItem>(request);

        await _orderItemService.AddAsync(orderItem);

        var response = _mapper.Map<OrderItemReadResponse>(orderItem);

        return Ok(response);
    }
}