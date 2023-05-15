using Order.Host.Models.Dtos;
using Order.Host.Models.Enums;
using Order.Host.Models.Response;

namespace Order.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters);
    Task<BasketItemInfoDto?> GetCatalogItemInfoAsync(int productId);
}