﻿using Ciber.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ciber.Infrastructure.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(o => o.Address)
                .HasMaxLength(200);
        }
    }
}
