using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure.EntityConfigurations;

public class LineItemEntityConfiguration : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.ToTable("lineitems");
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.HasOne(l => l.Order)
            .WithMany(o => o.LineItems)
            .HasForeignKey(l => l.OrderId);
        builder.HasOne(l => l.Product)
            .WithMany() // Empty as we don't want navigation from Product
            .HasForeignKey(l => l.ProductId);
        builder.Property(l => l.Quantity)
            .IsRequired();
        builder.Property(l => l.Price)
            .IsRequired();
    }
}