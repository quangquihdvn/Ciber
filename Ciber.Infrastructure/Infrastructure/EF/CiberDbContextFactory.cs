using Ciber.Infrastructure.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Ciber.Infrastructure.EF
{
    public class CiberDbContextFactory : IDesignTimeDbContextFactory<CiberDbContext>
    {
        public CiberDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{Environments.Development}.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MainDatabase");
            var optionsBuilder = new DbContextOptionsBuilder<CiberDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new CiberDbContext(optionsBuilder.Options);
        }
    }
}
