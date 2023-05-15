using Order.Host.Data;
using Order.Host.Models.Dtos;
using Order.Host.Models.Enums;
using Order.Host.Models.Response;
using Order.Host.Repositories.Interfaces;
using Order.Host.Services.Interfaces;

namespace Order.Host.Services;

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