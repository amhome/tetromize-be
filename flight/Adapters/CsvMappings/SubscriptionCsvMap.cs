using CsvHelper.Configuration;
using Tetromize.Models;

namespace Tetromize.Adapters
{
    public class SubscriptionCsvMap : ClassMap<Subscription>
    {
        private static int idCounter = 1;
        public SubscriptionCsvMap()
        {
            Map(x => x.Id).Convert(row => idCounter++);
            Map(x => x.AgencyId).Name("agency_id");
            Map(x => x.DestinationCityId).Name("destination_city_id");
            Map(x => x.OriginCityId).Name("origin_city_id");
        }
    }
}