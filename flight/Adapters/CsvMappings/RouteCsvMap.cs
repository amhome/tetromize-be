using CsvHelper.Configuration;
using Tetromize.Models;

namespace Tetromize.Adapters
{
    public class RouteCsvMap : ClassMap<Route>
    {
        public RouteCsvMap()
        {
            Map(x => x.DepartureDate).Name("departure_date");
            Map(x => x.DestinationCityId).Name("destination_city_id");
            Map(x => x.Id).Name("route_id");
            Map(x => x.OriginCityId).Name("origin_city_id");
        }
    }
}