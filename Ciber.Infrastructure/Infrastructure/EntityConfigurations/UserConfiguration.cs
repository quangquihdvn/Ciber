using Ciber.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ciber.Infrastructure.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.HasIndex(e => e.Id);
            builder.HasIndex(e => e.UserName);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Phone)
                .HasMaxLength(50);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .HasMaxLength(255);

            builder.Property(e => e.Address)
                .HasMaxLength(500);
        }
    }
}
