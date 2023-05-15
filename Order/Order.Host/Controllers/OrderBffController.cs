using Catalog.Host.Configurations;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class OrderBffController : ControllerBase
{
    private readonly ILogger<OrderBffController> _logger;
    private readonly IOrderItemService _orderItemService;
    private readonly IOptions<OrderConfig> _config;

    public OrderBffController(
        ILogger<OrderBffController> logger,
        IOrderItemService orderItemService,
        IOptions<OrderConfig> config)
    {
        _logger = logger;
        _orderItemService = orderItemService;
        _config = config;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetOrderItem(int orderId)
    {
        var result = await _orderItemService.GetOrderItemAsync(orderId);
        return Ok(result);
    }
}