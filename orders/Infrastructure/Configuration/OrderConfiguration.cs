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
        
        
        builder.HasOne(o => o.CurrentStatus)
            .WithMany()
            .HasForeignKey(o => o.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.ShoppingCart)
            .WithOne(x => x.Order)
            .HasForeignKey<Order>(x => x.ShoppingCartId);

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(o => o.StatusId);

    }
}