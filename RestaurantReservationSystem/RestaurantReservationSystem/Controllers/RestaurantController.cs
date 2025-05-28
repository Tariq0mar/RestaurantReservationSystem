using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Restaurant;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;
    private readonly IMapper _mapper;

    public RestaurantController(IRestaurantService restaurantService,
        IMapper mapper)
    {
        _restaurantService = restaurantService ?? throw new ArgumentNullException(nameof(restaurantService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestaurantReadResponse>>> GetRestaurants()
    {
        var restaurants = await _restaurantService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<RestaurantReadResponse>>(restaurants));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RestaurantReadResponse>> GetRestaurant(int id)
    {
        var restaurant = await _restaurantService.GetByIdAsync(id);
        if (restaurant == null)
            return NotFound();

        return Ok(_mapper.Map<RestaurantReadResponse>(restaurant));
    }
}