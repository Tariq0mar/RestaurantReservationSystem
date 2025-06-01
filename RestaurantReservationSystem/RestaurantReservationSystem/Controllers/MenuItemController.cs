using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
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

    [HttpPost]
    public async Task<ActionResult<MenuItemReadResponse>> CreateMenuItem([FromBody] MenuItemCreateRequest request)
    {
        var menuItem = _mapper.Map<MenuItem>(request);

        await _menuItemService.AddAsync(menuItem);

        var response = _mapper.Map<MenuItemReadResponse>(menuItem);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateMenuItem(int id, [FromBody] MenuItemUpdateRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest("ID in URL and request body must match.");
        }

        var existingMenuItem = await _menuItemService.GetByIdAsync(id);
        if (existingMenuItem is null)
        {
            return NotFound();
        }

        _mapper.Map(request, existingMenuItem);

        await _menuItemService.UpdateAsync(existingMenuItem);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMenuItem(int id)
    {
        var existingMenuItem = await _menuItemService.GetByIdAsync(id);
        if (existingMenuItem is null)
        {
            return NotFound();
        }

        await _menuItemService.DeleteAsync(id);
        return NoContent();
    }
}