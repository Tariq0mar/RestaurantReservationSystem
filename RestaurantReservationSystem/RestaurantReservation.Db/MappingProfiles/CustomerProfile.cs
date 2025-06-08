using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models.Customer;

namespace RestaurantReservation.Db.MappingProfiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerCreateRequest, Customer>();

        CreateMap<CustomerUpdateRequest, Customer>();

        CreateMap<Customer, CustomerReadResponse>();
    }
}