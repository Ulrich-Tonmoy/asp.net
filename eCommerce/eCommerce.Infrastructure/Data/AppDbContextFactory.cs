using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace eCommerce.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../eCommerce.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            // Create DbContextOptions
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("Local"); // Ensure this matches the key in your appsettings.json

            builder.UseSqlServer(connectionString); // Or UseNpgsql, UseMySql, etc.

            return new AppDbContext(builder.Options);
        }
    }
}
