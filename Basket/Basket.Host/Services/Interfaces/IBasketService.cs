using Basket.Host.Models;
using Basket.Host.Models.Dto;

namespace Basket.Host.Services.Interfaces;

public interface IBasketService
{
    Task Add(string userId, BasketItemDto item);
    Task<BasketItemInfoDto> Get(string userId);
}