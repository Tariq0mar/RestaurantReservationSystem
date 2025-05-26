using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Models.Employee;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly RestaurantReservationDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeController(RestaurantReservationDbContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetEmployees()
    {
        var employeeEntities = await _context.Employees.ToListAsync();

        return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employeeEntities));
    }
}