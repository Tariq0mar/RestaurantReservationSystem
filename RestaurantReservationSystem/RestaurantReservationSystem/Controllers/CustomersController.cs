using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Models.Customer;

namespace RestaurantReservationSystem.Controllers;

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
            return NotFound();

        return Ok(_mapper.Map<CustomerReadResponse>(customer));
    }
}
