using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Customer;

namespace RestaurantReservationSystem.Controllers;

[Authorize]
[ApiController]
[Route("api/customers")]
public class CustomerControllers : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerControllers(ICustomerService customerService,
        IMapper mapper)
    {
        _customerService = customerService ?? throw new ArgumentException(nameof(customerService));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerReadResponse>>> GetCustomers()
    {
        var customerEntities = await _customerService.GetAllAsync();

        return Ok(_mapper.Map<IEnumerable<CustomerReadResponse>>(customerEntities));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerReadResponse>> GetCustomer(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<CustomerReadResponse>(customer);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerReadResponse>> CreateCustomer([FromBody] CustomerCreateRequest request)
    {
        var customer = _mapper.Map<Customer>(request);

        await _customerService.AddAsync(customer);

        var response = _mapper.Map<CustomerReadResponse>(customer);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> UpdateCustomer(int id, [FromBody] CustomerUpdateRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest("ID in URL and request body must match.");
        }

        var existingCustomer = await _customerService.GetByIdAsync(id);
        if (existingCustomer is null)
        {
            return NotFound();
        }

        _mapper.Map(request, existingCustomer);

        var foundedId = await _customerService.UpdateAsync(existingCustomer);

        if (foundedId == -1)
        {
            return NotFound();
        }

        return Ok(foundedId);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteCustomer(int id)
    {
        var foundedId = await _customerService.DeleteAsync(id);

        if (foundedId == -1)
        {
            return NotFound();
        }

        return Ok(foundedId);
    }
}