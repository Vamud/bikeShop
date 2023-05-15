using Order.Host.Models.Dtos;
using Order.Host.Data.Entities;

namespace Order.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OrderItem, OrderItemDto>();
    }
}