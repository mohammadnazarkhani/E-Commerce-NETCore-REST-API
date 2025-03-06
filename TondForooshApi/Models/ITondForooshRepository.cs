using System;

namespace TondForooshApi.Models;

public interface ITondForooshRepository
{
    IQueryable<Product> Products { get; }
}
