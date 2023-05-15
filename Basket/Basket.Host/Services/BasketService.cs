using Basket.Host.Configurations;
using Basket.Host.Models;
using Basket.Host.Models.Dto;
using Basket.Host.Models.Request;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;
    private readonly IInternalHttpClientService _httpClientService;
    private readonly IOptions<BasketConfig> _config;

    public BasketService(ICacheService cacheService, IInternalHttpClientService httpClientService, IOptions<BasketConfig> config)
    {
        _cacheService = cacheService;
        _httpClientService = httpClientService;
        _config = config;
    }
    
    public async Task Add(string userId, BasketItemDto item)
    {
       await _cacheService.AddOrUpdateAsync(userId, item);
    }

    public async Task<BasketItemInfoDto> Get(string userId)
    {
        var result = await _cacheService.GetAsync<BasketItemDto>(userId);

        var request = new GetItemRequest() { ProductId = result.ProductId };

        var response = await _httpClientService.SendAsync<BasketItemInfoDto, GetItemRequest>(_config.Value.CatalogApi + "/api/v1/CatalogItem/GetItemInfo", HttpMethod.Post, request );

        return response;
    }
}