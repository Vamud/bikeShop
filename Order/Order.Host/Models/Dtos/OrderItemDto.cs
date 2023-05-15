using Order.Host.Data.Entities;

namespace Order.Host.Models.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IEnumerable<OrderProductItem> Items { get; set; } = null!;
        public string Data { get; set; } = null!;
    }
}
