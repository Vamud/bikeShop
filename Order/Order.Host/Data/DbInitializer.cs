using Order.Host.Data.Entities;

namespace Order.Host.Data;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.OrderItems.Any())
        {
            await context.OrderItems.AddRangeAsync(GetPreconfiguredOrderItems());

            await context.SaveChangesAsync();
        }

        if (!context.OrderItems.Any())
        {
            await context.OrderProductItems.AddRangeAsync(GetPreconfiguredOrderProductItems());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<OrderItem> GetPreconfiguredOrderItems()
    {
        return new List<OrderItem>()
            {
                new OrderItem() { UserId = 818727 },
                new OrderItem() { UserId = 88421113 }
            };
    }

    private static IEnumerable<OrderProductItem> GetPreconfiguredOrderProductItems()
    {
        return new List<OrderProductItem>()
            {
                new OrderProductItem() { OrderId = 1, ProductId = 2, Quantity = 1 },
                new OrderProductItem() { OrderId = 1, ProductId = 8, Quantity = 1 },
                new OrderProductItem() { OrderId = 2, ProductId = 5, Quantity = 1 },
                new OrderProductItem() { OrderId = 2, ProductId = 9, Quantity = 1 },
            };
    }
}