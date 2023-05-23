using Ciber.Infrastructure.EntityConfigurations;
using Ciber.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ciber.Infrastructure.Infrastructure.EF
{
    public class CiberDbContext : DbContext
    {
        public CiberDbContext() : base()
        { }

        public CiberDbContext(DbContextOptions<CiberDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
