using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure.EntityConfigurations;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(c => c.Name)
            .IsRequired();
        builder.Property(c => c.Email)
            .IsRequired();
        builder.Property(c => c.Phone)
            .IsRequired();
    }
}