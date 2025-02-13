using Tetromize.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tetromize.Data
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            AppDbContextConfig.SeedData(builder);

            builder.Entity<Flight>().HasIndex(x => x.RouteId);
            builder.Entity<Subscription>().HasIndex(x => x.AgencyId);
            builder.Entity<Route>().HasIndex(x => x.OriginCityId);
            builder.Entity<Route>().HasIndex(x => x.DestinationCityId);
        }
    }
}