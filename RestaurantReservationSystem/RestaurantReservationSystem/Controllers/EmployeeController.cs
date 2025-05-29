using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Customer;
using RestaurantReservation.Db.Models.Employee;
using RestaurantReservation.Db.Services;

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

    [HttpPost]
    public async Task<ActionResult<EmployeeReadResponse>> CreateEmployee([FromBody] EmployeeCreateRequest request)
    {
        var employee = _mapper.Map<Employee>(request);

        await _employeeService.AddAsync(employee);

        var response = _mapper.Map<EmployeeReadResponse>(employee);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeUpdateRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest("ID in URL and request body must match.");
        }

        var existingEmployee = await _employeeService.GetByIdAsync(id);
        if (existingEmployee is null)
        {
            return NotFound();
        }

        _mapper.Map(request, existingEmployee);

        await _employeeService.UpdateAsync(existingEmployee);

        return NoContent();
    }
}