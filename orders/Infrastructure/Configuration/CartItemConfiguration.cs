using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure.Configuration;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(x => x.VariantId)
            .IsRequired();
        builder.Property(x => x.Name)
            .IsRequired();
        builder.Property(x => x.Description)
            .IsRequired();
        builder.Property(x => x.Price)
            .IsRequired();
        builder.Property(x => x.Size)
            .IsRequired();
        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.HasOne(x => x.ShoppingCart)
            .WithMany(x => x.CartItems)
            .HasForeignKey(x => x.ShoppingCartId);
    }
}