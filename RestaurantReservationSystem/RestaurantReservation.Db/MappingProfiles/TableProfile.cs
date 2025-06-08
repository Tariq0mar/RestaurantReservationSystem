using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models.Table;

namespace RestaurantReservation.Db.MappingProfiles;

public class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<TableCreateRequest, Table>();

        CreateMap<TableUpdateRequest, Table>();

        CreateMap<Table, TableReadResponse>();
    }
}