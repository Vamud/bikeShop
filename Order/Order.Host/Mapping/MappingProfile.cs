using Catalog.Host.Models.Dtos;
using Order.Host.Data.Entities;
using Order.Host.Models.Dtos;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OrderItem, OrderItemDto>();
    }
}