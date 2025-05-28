using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Employee;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeService employeeService,
        IMapper mapper)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeReadResponse>>> GetEmployees()
    {
        var employees = await _employeeService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<EmployeeReadResponse>>(employees));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeReadResponse>> GetEmployee(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);
        if (employee == null)
            return NotFound();

        return Ok(_mapper.Map<EmployeeReadResponse>(employee));
    }
}