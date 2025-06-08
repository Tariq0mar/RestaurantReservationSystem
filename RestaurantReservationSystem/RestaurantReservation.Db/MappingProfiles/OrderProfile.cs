using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models.Order;

namespace RestaurantReservation.Db.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderCreateRequest, Order>();

        CreateMap<OrderUpdateRequest, Order>();

        CreateMap<Order, OrderReadResponse>();
    }
}