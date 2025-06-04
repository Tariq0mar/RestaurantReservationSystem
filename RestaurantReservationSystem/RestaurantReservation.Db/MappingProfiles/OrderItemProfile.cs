using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models.OrderItem;

namespace RestaurantReservation.Db.MappingProfiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItemCreateRequest, OrderItem>();

        CreateMap<OrderItemUpdateRequest, OrderItem>();

        CreateMap<OrderItem, OrderItemReadResponse>();
    }
}