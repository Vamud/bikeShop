using Order.Host.Data.Entities;
using Order.Host.Models.Dtos;

namespace Order.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogItemPictureResolver<CatalogItemDto>, string>(c => c.PictureFileName));
        CreateMap<CatalogBrand, CatalogBrandDto>();
        CreateMap<CatalogType, CatalogTypeDto>();
        CreateMap<CatalogItem, BasketItemInfoDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogItemPictureResolver<BasketItemInfoDto>, string>(c => c.PictureFileName));
    }
}