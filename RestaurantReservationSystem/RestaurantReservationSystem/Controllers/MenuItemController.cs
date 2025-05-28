using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.MenuItem;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/menu-items")]
public class MenuItemController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;
    private readonly IMapper _mapper;

    public MenuItemController(IMenuItemService menuItemService,
        IMapper mapper)
    {
        _menuItemService = menuItemService ?? throw new ArgumentNullException(nameof(menuItemService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuItemReadResponse>>> GetMenuItems()
    {
        var menuItems = await _menuItemService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<MenuItemReadResponse>>(menuItems));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MenuItemReadResponse>> GetMenuItem(int id)
    {
        var menuItem = await _menuItemService.GetByIdAsync(id);
        if (menuItem == null)
            return NotFound();

        return Ok(_mapper.Map<MenuItemReadResponse>(menuItem));
    }
}