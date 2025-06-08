using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.User;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/users")]
public class UserControllers : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserControllers(IUserService userService,
        IMapper mapper)
    {
        _userService = userService ?? throw new ArgumentException(nameof(userService));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserReadResponse>>> GetUsers()
    {
        var userEntities = await _userService.GetAllAsync();

        return Ok(_mapper.Map<IEnumerable<UserReadResponse>>(userEntities));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserReadResponse>> GetUser(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<UserReadResponse>(user);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<UserReadResponse>> CreateUser([FromBody] UserCreateRequest request)
    {
        var user = _mapper.Map<User>(request);

        await _userService.AddAsync(user);

        var response = _mapper.Map<UserReadResponse>(user);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> UpdateUser(int id, [FromBody] UserUpdateRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest("ID in URL and request body must match.");
        }

        var existingUser = await _userService.GetByIdAsync(id);
        if (existingUser is null)
        {
            return NotFound();
        }

        _mapper.Map(request, existingUser);

        var foundedId = await _userService.UpdateAsync(existingUser);

        if (foundedId == -1)
        {
            return NotFound();
        }

        return Ok(foundedId);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteUser(int id)
    {
        var foundedId = await _userService.DeleteAsync(id);

        if (foundedId == -1)
        {
            return NotFound();
        }

        return Ok(foundedId);
    }
}