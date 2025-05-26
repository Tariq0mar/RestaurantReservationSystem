using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Models.Customer;

namespace RestaurantReservationSystem.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerControllers : ControllerBase
{
    private readonly RestaurantReservationDbContext _context;
    private readonly IMapper _mapper;

    public CustomerControllers(RestaurantReservationDbContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetCustomers()
    {
        var customerEntities = await _context.Customers.ToListAsync();

        return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customerEntities));
    }
}
