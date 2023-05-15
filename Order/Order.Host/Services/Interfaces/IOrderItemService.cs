using Order.Host.Models.Dtos;

namespace Order.Host.Services.Interfaces;

public interface IOrderItemService
{
    Task<OrderItemDto?> GetOrderItemAsync(int orderId);
}