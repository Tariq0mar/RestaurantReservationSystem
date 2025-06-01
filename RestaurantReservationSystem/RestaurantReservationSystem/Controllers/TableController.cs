using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Table;
using RestaurantReservation.Db.Services;

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

    [HttpPost]
    public async Task<ActionResult<TableReadResponse>> CreateTable([FromBody] TableCreateRequest request)
    {
        var table = _mapper.Map<Table>(request);

        await _tableService.AddAsync(table);

        var response = _mapper.Map<TableReadResponse>(table);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTable(int id, [FromBody] TableUpdateRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest("ID in URL and request body must match.");
        }

        var existingTable = await _tableService.GetByIdAsync(id);
        if (existingTable is null)
        {
            return NotFound();
        }

        _mapper.Map(request, existingTable);

        var foundedId = await _tableService.UpdateAsync(existingTable);

        if (foundedId == -1)
        {
            return NotFound();
        }

        return Ok(foundedId);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteTable(int id)
    {
        var existingTable = await _tableService.GetByIdAsync(id);
        if (existingTable is null)
        {
            return NotFound();
        }

        await _tableService.DeleteAsync(id);
        return Ok(id);
    }
}