using Order.Host.Data;
using Order.Host.Data.Entities;
using Order.Host.Models.Dtos;

namespace Order.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? brandFilter, int? typeFilter);
    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<BasketItemInfoDto> GetByIdAsync(int productId);
}