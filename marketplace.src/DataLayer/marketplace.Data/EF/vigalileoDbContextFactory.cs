using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace marketplace.Data.EF
{
    public class marketplace : IDesignTimeDbContextFactory<marketplaceDbContext>
    {
        public marketplaceDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("marketplaceDb");

            var optionsBuilder = new DbContextOptionsBuilder<marketplaceDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new marketplaceDbContext(optionsBuilder.Options);
        }
    }
}
