using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Table;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/tables")]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;
    private readonly IMapper _mapper;

    public TableController(ITableService tableService,
        IMapper mapper)
    {
        _tableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TableReadResponse>>> GetTables()
    {
        var tables = await _tableService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<TableReadResponse>>(tables));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TableReadResponse>> GetTable(int id)
    {
        var table = await _tableService.GetByIdAsync(id);
        if (table is null)
            return NotFound();

        return Ok(_mapper.Map<TableReadResponse>(table));
    }
}