using CsvHelper.Configuration;
using Tetromize.Models;

namespace Tetromize.Adapters
{
    public class FlightCsvMap : ClassMap<Flight>
    {
        public FlightCsvMap()
        {
            Map(x => x.AirlineId).Name("airline_id");
            Map(x => x.ArrivalTime).Name("arrival_time");
            Map(x => x.DepartureTime).Name("departure_time");
            Map(x => x.Id).Name("flight_id");
            Map(x => x.RouteId).Name("route_id");
        }
    }
}