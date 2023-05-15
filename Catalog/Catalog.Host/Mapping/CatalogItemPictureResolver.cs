using Order.Host.Configurations;
using Order.Host.Data.Entities;
using Order.Host.Models.Dtos;

namespace Order.Host.Mapping;

public class CatalogItemPictureResolver<T> : IMemberValueResolver<CatalogItem, T, string, object>
{
    private readonly CatalogConfig _config;

    public CatalogItemPictureResolver(IOptionsSnapshot<CatalogConfig> config)
    {
        _config = config.Value;
    }

    public object Resolve(CatalogItem source, T destination, string sourceMember, object destMember, ResolutionContext context)
    {
        return $"{_config.CdnHost}/{_config.ImgUrl}/{sourceMember}";
    }
}