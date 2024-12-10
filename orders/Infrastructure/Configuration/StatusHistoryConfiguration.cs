using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure.Configuration;

public class StatusHistoryConfiguration : IEntityTypeConfiguration<StatusHistory>
{
    public void Configure(EntityTypeBuilder<StatusHistory> builder)
    {
        builder.HasKey(sh => sh.Id);
        builder.Property(sh => sh.ChangedAt)
            .IsRequired();

        builder.HasOne(sh => sh.Order)
            .WithMany(o => o.StatusHistories)
            .HasForeignKey(sh => sh.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sh => sh.Status)
            .WithMany()
            .HasForeignKey(sh => sh.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}