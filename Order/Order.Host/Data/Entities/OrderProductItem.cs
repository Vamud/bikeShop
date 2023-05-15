namespace Order.Host.Data.Entities
{
    public class OrderProductItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public OrderItem Order { get; set; } = null!;
    }
}
