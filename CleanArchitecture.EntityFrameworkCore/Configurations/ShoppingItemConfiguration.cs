using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.EntityFrameworkCore.Configurations
{
    public class ShoppingItemConfiguration : IEntityTypeConfiguration<ShoppingItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingItem> builder)
        {
            builder.Property(e => e.AddedTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.ModifiedTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}