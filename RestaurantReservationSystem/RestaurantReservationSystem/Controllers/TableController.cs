using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Models.Table;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/tables")]
public class TableController : ControllerBase
{
    private readonly RestaurantReservationDbContext _context;
    private readonly IMapper _mapper;

    public TableController(RestaurantReservationDbContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TableReadDto>>> GetTables()
    {
        var tableEntities = await _context.Tables.ToListAsync();

        return Ok(_mapper.Map<IEnumerable<TableReadDto>>(tableEntities));
    }
}