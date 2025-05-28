using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.OrderItem;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/orderItems")]
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
    public async Task<ActionResult<IEnumerable<OrderItemReadDto>>> GetOrderItems()
    {
        var orderItems = await _orderItemService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<OrderItemReadDto>>(orderItems));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderItemReadDto>> GetOrderItem(int id)
    {
        var orderItem = await _orderItemService.GetByIdAsync(id);
        if (orderItem == null)
            return NotFound();

        return Ok(_mapper.Map<OrderItemReadDto>(orderItem));
    }
}