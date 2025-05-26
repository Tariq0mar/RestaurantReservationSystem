using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Models.Restaurant;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantController : ControllerBase
{
    private readonly RestaurantReservationDbContext _context;
    private readonly IMapper _mapper;

    public RestaurantController(RestaurantReservationDbContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestaurantReadDto>>> GetRestaurants()
    {
        var restaurantEntities = await _context.Restaurants.ToListAsync();

        return Ok(_mapper.Map<IEnumerable<RestaurantReadDto>>(restaurantEntities));
    }
}