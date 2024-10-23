﻿using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.API.Domain.Entities;

namespace VerticalSliceArchitecture.API.Infrastructure.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);

        // Additional configurations
    }
}