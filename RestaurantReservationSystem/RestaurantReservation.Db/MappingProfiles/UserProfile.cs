using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models.User;

namespace RestaurantReservation.Db.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateRequest, User>();

        CreateMap<UserUpdateRequest, User>();

        CreateMap<User, UserReadResponse>();
    }
}