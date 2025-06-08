using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Restaurant;
using RestaurantReservation.Db.Services;

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

    [HttpPost]
    public async Task<ActionResult<RestaurantReadResponse>> CreateRestaurant([FromBody] RestaurantCreateRequest request)
    {
        var restaurant = _mapper.Map<Restaurant>(request);

        await _restaurantService.AddAsync(restaurant);

        var response = _mapper.Map<RestaurantReadResponse>(restaurant);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> UpdateRestaurant(int id, [FromBody] RestaurantUpdateRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest("ID in URL and request body must match.");
        }

        var existingRestaurant = await _restaurantService.GetByIdAsync(id);
        if (existingRestaurant is null)
        {
            return NotFound();
        }

        _mapper.Map(request, existingRestaurant);

        var foundedId = await _restaurantService.UpdateAsync(existingRestaurant);

        if (foundedId == -1)
        {
            return NotFound();
        }

        return Ok(foundedId);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteRestaurant(int id)
    {
        var existingRestaurant = await _restaurantService.GetByIdAsync(id);
        if (existingRestaurant is null)
        {
            return NotFound();
        }

        await _restaurantService.DeleteAsync(id);
        return Ok(id);
    }
}