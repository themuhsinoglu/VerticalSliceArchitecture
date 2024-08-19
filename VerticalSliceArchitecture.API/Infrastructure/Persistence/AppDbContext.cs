using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.API.Domain.Entities;

namespace VerticalSliceArchitecture.API.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Additional configurations
    }
}