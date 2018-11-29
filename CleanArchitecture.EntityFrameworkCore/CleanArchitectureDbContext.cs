using CleanArchitecture.Domain.Entities;
using CleanArchitecture.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.EntityFrameworkCore
{
    public class CleanArchitectureDbContext : DbContext
    {
        public CleanArchitectureDbContext(DbContextOptions<CleanArchitectureDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShoppingItemConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingListConfiguration());
        }
    }
}