using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Models.MenuItem;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/MenuItems")]
public class MenuItemController : ControllerBase
{
    private readonly RestaurantReservationDbContext _context;
    private readonly IMapper _mapper;

    public MenuItemController(RestaurantReservationDbContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuItemReadDto>>> GetMenuItems()
    {
        var menuItemEntities = await _context.MenuItems.ToListAsync();

        return Ok(_mapper.Map<IEnumerable<MenuItemReadDto>>(menuItemEntities));
    }
}