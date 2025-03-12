using System;

namespace TondForooshApi.Models;

public interface ITondForooshRepository
{
    IQueryable<Product> Products { get; }
    Task<long> AddAsync(Product product);
}
