// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using Microsoft.EntityFrameworkCore;
using Tetromize.Data;

DateTime fromDate = new DateTime(2018, 1, 1);
DateTime toDate = new DateTime(2018, 1, 15);
int agencyId = 1;

// algorithm
using var context = new AppDbContext();

var _subscriptions = await context.Subscriptions.Where(x => x.AgencyId == agencyId).ToListAsync();

var routesQuery = context.Routes.Where(x => x.DepartureDate > fromDate && x.DepartureDate < toDate).AsQueryable();
routesQuery = routesQuery.Where(x => _subscriptions.Any(s => s.OriginCityId == x.OriginCityId && s.DestinationCityId == x.DestinationCityId));
var _routes = await routesQuery.Include(x => x.Flights).ToListAsync();

foreach (var group in _routes.SelectMany(x => x.Flights).GroupBy(x => x.AirlineId))
{
    var newOnes = group.Where(x => 
        !group.Any(y => x.DepartureTime >= y.DepartureTime.AddDays(-7).AddMinutes(-30) && x.DepartureTime <= y.DepartureTime.AddDays(-7).AddMinutes(30)));
    var discontinued = group.Where(x => 
        !group.Any(y => x.DepartureTime >= y.DepartureTime.AddDays(7).AddMinutes(-30) && x.DepartureTime <= y.DepartureTime.AddDays(7).AddMinutes(-30)));
}
