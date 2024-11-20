using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure.EntityConfigurations;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(o => o.CustomerId)
            .IsRequired();
        builder.Property(o => o.ProductId)
            .IsRequired();
    }
}