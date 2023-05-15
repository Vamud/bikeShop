using Order.Host.Data;
using Order.Host.Data.Entities;

namespace Order.Host.Repositories.Interfaces;

public interface IOrderItemRepository
{
    Task<OrderItem> GetByOrderIdAsync(int userId);
   /* Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);*/
}