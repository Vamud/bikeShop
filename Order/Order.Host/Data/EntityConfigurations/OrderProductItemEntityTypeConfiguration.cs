using Order.Host.Data.Entities;

namespace Order.Host.Data.EntityConfigurations
{
    public class OrderProductItemEntityTypeConfiguration
        : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("Order");

            builder.Property(f => f.Id)
                .UseHiLo("order_hilo")
                .IsRequired();

            builder.Property(f => f.UserId)
                .IsRequired();
        }
    }
}
