using Microsoft.EntityFrameworkCore;

namespace Flight.Data
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            AppDbContextConfig.SeedData(builder);
        }
    }
}