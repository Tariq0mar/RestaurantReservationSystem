using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models.Restaurant;

namespace RestaurantReservation.Db.MappingProfiles;

public class RestaurantProfile : Profile 
{
    public RestaurantProfile()
    {
        CreateMap<RestaurantCreateRequest, Restaurant>();

        CreateMap<RestaurantUpdateRequest, Restaurant>();

        CreateMap<Restaurant, RestaurantReadResponse>();
    }
}