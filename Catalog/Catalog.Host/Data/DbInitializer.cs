using Order.Host.Data.Entities;

namespace Order.Host.Data;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogBrands.Any())
        {
            await context.CatalogBrands.AddRangeAsync(GetPreconfiguredCatalogBrands());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogTypes.Any())
        {
            await context.CatalogTypes.AddRangeAsync(GetPreconfiguredCatalogTypes());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogItems.Any())
        {
            await context.CatalogItems.AddRangeAsync(GetPreconfiguredItems());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
    {
        return new List<CatalogBrand>()
        {
            new CatalogBrand() { Brand = "Pride" },
            new CatalogBrand() { Brand = "Bianchi" },
            new CatalogBrand() { Brand = "Marin" },
            new CatalogBrand() { Brand = "Scott" }
        };
    }

    private static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
    {
        return new List<CatalogType>()
        {
            new CatalogType() { Type = "Mountain" },
            new CatalogType() { Type = "Road" },
            new CatalogType() { Type = "Hybrid" },
            new CatalogType() { Type = "Cruiser" }
        };
    }

    private static IEnumerable<CatalogItem> GetPreconfiguredItems()
    {
        return new List<CatalogItem>()
            {
                new CatalogItem() { CatalogTypeId = 1, CatalogBrandId = 1, AvailableStock = 20, Description = "26 Pride STELLA 6.1 XS 2022 black", Name = "Pride STELLA", Price = 320.5m, PictureFileName = "1.png" },
                new CatalogItem() { CatalogTypeId = 1, CatalogBrandId = 1, AvailableStock = 20, Description = "29 Pride STEAMROLLER M 2023 green", Name = "Pride STEAMROLLER", Price = 1103.3m, PictureFileName = "2.png" },
                new CatalogItem() { CatalogTypeId = 1, CatalogBrandId = 1, AvailableStock = 20, Description = "29 Pride REVENGE 9.2 M 2023", Name = "Pride REVENGE", Price = 1200.2m, PictureFileName = "3.png" },
                new CatalogItem() { CatalogTypeId = 4, CatalogBrandId = 1, AvailableStock = 20, Description = "29 Pride ROCX DIRT Tour L 2022 green", Name = "Pride ROCX DIRT", Price = 1500.5m, PictureFileName = "4.png" },
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 1, AvailableStock = 20, Description = "28 Pride JET ROCKET XL 2023 grey", Name = "Pride JET ROCKET", Price = 1804.5m, PictureFileName = "5.png" },
                new CatalogItem() { CatalogTypeId = 1, CatalogBrandId = 2, AvailableStock = 20, Description = "29 Bianchi OFF-ROAD MAGMA 9.0 DEORE 1X11S BOOST 2021 celeste", Name = "Bianchi OFF-ROAD", Price = 800.5m, PictureFileName = "6.png" },
                new CatalogItem() { CatalogTypeId = 3, CatalogBrandId = 2, AvailableStock = 20, Description = "28 Bianchi IMPULSO ALLROAD GRX600 2021 black/titanium", Name = "Bianchi IMPULSO ALLROAD", Price = 2100.7m, PictureFileName = "7.png" },
                new CatalogItem() { CatalogTypeId = 4, CatalogBrandId = 2, AvailableStock = 20, Description = "28 Bianchi GRAVEL ARCADEX GRX815 DI2 S 2021 gold/blue", Name = "Bianchi GRAVEL ARCADEX", Price = 4606.2m, PictureFileName = "8.png" },
                new CatalogItem() { CatalogTypeId = 1, CatalogBrandId = 3, AvailableStock = 20, Description = "29 Marin RIFT ZONE XL 2022 black/roarange/red", Name = "Marin RIFT ZONE", Price = 2302.5m, PictureFileName = "9.png" },
                new CatalogItem() { CatalogTypeId = 3, CatalogBrandId = 3, AvailableStock = 20, Description = "28 Marin PRESIDIO S 2023 black/grey", Name = "Marin PRESIDIO", Price = 600.5m, PictureFileName = "10.png" },
                new CatalogItem() { CatalogTypeId = 2, CatalogBrandId = 3, AvailableStock = 20, Description = "28 Marin HEADLANDS M 2022 charcoal/black/roarange", Name = "Marin HEADLANDS", Price = 1150.5m, PictureFileName = "11.png" },
                new CatalogItem() { CatalogTypeId = 4, CatalogBrandId = 4, AvailableStock = 20, Description = "28 Scott SPEEDSTER M 2022 grey", Name = "Scott SPEEDSTER", Price = 1240.5m, PictureFileName = "12.png" }
            };
    }
}