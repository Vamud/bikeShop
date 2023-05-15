using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Response;
using Order.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface IOrderItemService
{
    Task<OrderItemDto?> GetOrderItemAsync(int orderId);
}