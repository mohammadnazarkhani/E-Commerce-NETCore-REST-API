using System;
using Core.DTOs.Product;
using Core.Entities;

namespace Core.Tests.Mappings.ProductMappings;

public class UpdateFromDtoMethodTests
{
        Category category = new()
    {
        Id = 1,
        Name = "cat1"
    };

    Product product = new()
    {
        Id = 1,
        Name = "oldName",
        Description = "oldDescription",
        StockQuantity = 0,
        Price = 100M,
    };
}
