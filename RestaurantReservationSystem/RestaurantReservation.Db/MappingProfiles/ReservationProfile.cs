using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models.Reservation;

namespace RestaurantReservation.Db.MappingProfiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<ReservationCreateRequest, Reservation>();

        CreateMap<ReservationUpdateRequest, Reservation>();

        CreateMap<Reservation, ReservationReadResponse>();
    }
}