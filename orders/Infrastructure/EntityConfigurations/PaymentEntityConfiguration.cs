using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure.EntityConfigurations;

public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payments");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.HasOne(p => p.Order)
            .WithOne(o => o.Payment)
            .HasForeignKey<Payment>(p => p.OrderId);
        builder.Property(p => p.PaymentMethod)
            .IsRequired();
        builder.Property(p => p.Timestamp)
            .IsRequired();
        builder.Property(p => p.PaymentIdentifier)
            .IsRequired();
        builder.Property(p => p.PaymentConfirmation);
        builder.Property(p => p.Amount)
            .IsRequired();
    }
}