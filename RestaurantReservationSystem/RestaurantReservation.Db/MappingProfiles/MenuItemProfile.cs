using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models.Customer;
using RestaurantReservation.Db.Models.MenuItem;

namespace RestaurantReservation.Db.MappingProfiles;

public class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        CreateMap<MenuItemCreateRequest, MenuItem>();

        CreateMap<MenuItemUpdateRequest, MenuItem>();

        CreateMap<MenuItem, MenuItemReadResponse>();
    }
}