using Infrastructure.Identity;

namespace Catalog.Host.Configurations;

public class OrderConfig
{
    public string CdnHost { get; set; } = null!;

    public string ConnectionString { get; set; } = null!;
}