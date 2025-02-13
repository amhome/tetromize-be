using Microsoft.EntityFrameworkCore;
using Tetromize.Adapters;
using Tetromize.Models;

namespace Tetromize.Data
{
    public class AppDbContextConfig
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Add any seed data here
            var subscriptions = CsvDataAdapter.ReadFrom<Subscription, SubscriptionCsvMap>
                (Path.Combine(Directory.GetCurrentDirectory(),"subscriptions.csv"));
            modelBuilder.Entity<Subscription>().HasData(subscriptions);

            var routes = CsvDataAdapter.ReadFrom<Route, RouteCsvMap>
                (Path.Combine(Directory.GetCurrentDirectory(), "routes.csv"));
            modelBuilder.Entity<Route>().HasData(routes);

            var flights = CsvDataAdapter.ReadFrom<Flight, FlightCsvMap>
                (Path.Combine(Directory.GetCurrentDirectory(), "flights.csv"));
            modelBuilder.Entity<Flight>().HasData(flights);
        }
    }
}