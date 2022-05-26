﻿using iWantApp_Proj1.Domain.Products;
using Microsoft.EntityFrameworkCore;
namespace iWantApp_Proj1.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }    
    public DbSet<Category> Categories { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .Property(p => p.Name).IsRequired();
        builder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);

        builder.Entity<Category>()
            .Property(p => p.Name).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurations)
    {
        configurations.Properties<string>()
            .HaveMaxLength(100);
    }
}