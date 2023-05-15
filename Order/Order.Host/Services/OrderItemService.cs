using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Order.Host.Models.Dtos;

namespace Catalog.Host.Services;

public class OrderItemService : BaseDataService<ApplicationDbContext>, IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public OrderItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IOrderItemRepository orderItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task<OrderItemDto?> GetOrderItemAsync(int orderId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _orderItemRepository.GetByOrderIdAsync(orderId);
            if (result == null)
            {
                return null;
            }

            return _mapper.Map<OrderItemDto>(result);
        });
    }
}