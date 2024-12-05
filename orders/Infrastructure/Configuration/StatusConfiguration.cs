using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure.Configuration;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.StatusName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.HasData(
            new Status { Id = 1, StatusName = "Pending" },
            new Status { Id = 2, StatusName = "Processing" },
            new Status { Id = 3, StatusName = "Shipped" },
            new Status { Id = 4, StatusName = "Delivered" },
            new Status { Id = 5, StatusName = "Cancelled" },
            new Status { Id = 6, StatusName = "Returned" }
        );
    }
}