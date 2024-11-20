using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure.EntityConfigurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Name)
            .IsRequired();
        builder.Property(p => p.Price)
            .IsRequired();
    }
}