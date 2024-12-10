using auth.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace auth.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(u => u.Username)
            .IsUnique();
        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.Role)
            .IsRequired()
            .HasMaxLength(50);


        builder.HasData(
            new User { Id = 1, Username = "admin", Password = "admin", Role = "ADMIN" },
            new User { Id = 2, Username = "user", Password = "user", Role = "CUSTOMER" }
        );
    }
}