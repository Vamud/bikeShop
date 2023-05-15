namespace Order.Host.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<OrderProductItem> Items { get; set; } = new List<OrderProductItem>();
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
