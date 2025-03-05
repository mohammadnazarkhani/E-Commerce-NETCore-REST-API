using System;
using Microsoft.EntityFrameworkCore;

namespace TondForooshApi.Models;

public class TFDbContext : DbContext
{
    public TFDbContext(DbContextOptions<TFDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; } 
}
