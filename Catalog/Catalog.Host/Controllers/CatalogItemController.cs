using Order.Host.Models.Dtos;
using Order.Host.Models.Requests;
using Order.Host.Models.Response;
using Order.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Order.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.catalogitem")]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ILogger<CatalogItemController> _logger;
    private readonly ICatalogItemService _catalogItemService;
    private readonly ICatalogService _catalogService;

    public CatalogItemController(
        ILogger<CatalogItemController> logger,
        ICatalogItemService catalogItemService,
        ICatalogService catalogService)
    {
        _logger = logger;
        _catalogItemService = catalogItemService;
        _catalogService = catalogService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateProductRequest request)
    {
        var result = await _catalogItemService.AddAsync(request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(BasketItemInfoDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetItemInfo(BasketItemRequest request)
    {
        var result = await _catalogService.GetCatalogItemInfoAsync(request.ProductId);
        return Ok(result);
    }
}