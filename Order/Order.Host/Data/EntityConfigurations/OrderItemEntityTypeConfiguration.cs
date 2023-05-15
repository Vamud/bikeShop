using Order.Host.Data.Entities;

namespace Order.Host.Data.EntityConfigurations
{
    public class OrderItemEntityTypeConfiguration
        : IEntityTypeConfiguration<OrderProductItem>
    {
        public void Configure(EntityTypeBuilder<OrderProductItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.Property(f => f.Id)
                .UseHiLo("order_item_hilo")
                .IsRequired();

            builder.Property(f => f.ProductId)
                .IsRequired();

            builder.Property(f => f.Quantity)
                .IsRequired();

            builder.HasOne(f => f.Order)
                .WithMany(f => f.Items)
                .HasForeignKey(f => f.OrderId);
        }
    }
}
