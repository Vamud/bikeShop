using Order.Host.Data;
using Order.Host.Repositories.Interfaces;
using Order.Host.Data.Entities;

namespace Order.Host.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<OrderItemRepository> _logger;

    public OrderItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<OrderItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<OrderItem> GetByOrderIdAsync(int orderId)
    {
        IQueryable<OrderItem> query = _dbContext.OrderItems;

        query = query.Where(w => w.Id == orderId);

        return await query.FirstAsync();
    }

   /* public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item1 = new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        };
        var item = await _dbContext.AddAsync(item1);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }*/
}