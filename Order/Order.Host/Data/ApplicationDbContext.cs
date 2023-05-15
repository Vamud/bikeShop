using Order.Host.Data.Entities;
using Order.Host.Data.EntityConfigurations;

namespace Order.Host.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<OrderProductItem> OrderProductItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new OrderItemEntityTypeConfiguration());
        builder.ApplyConfiguration(new OrderProductItemEntityTypeConfiguration());
    }
}
