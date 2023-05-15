namespace Basket.Host.Models.Dto
{
    public class BasketItemInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = null!;
    }
}
