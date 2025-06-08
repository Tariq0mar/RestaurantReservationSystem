using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models.Employee;

namespace RestaurantReservation.Db.MappingProfiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeCreateRequest, Employee>();

        CreateMap<EmployeeUpdateRequest, Employee>();

        CreateMap<Employee, EmployeeReadResponse>();
    }
}