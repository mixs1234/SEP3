using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(o => o.ProductVariantId)
            .IsRequired();
        builder.Property(o => o.Quantity)
            .IsRequired();
    }
}