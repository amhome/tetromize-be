using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Tetromize.Adapters
{
    public static class CsvDataAdapter
    {
        public static List<T> ReadFrom<T, TMap>(string filePath) where TMap : ClassMap<T>
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<TMap>();
            return csv.GetRecords<T>().ToList();
        }
    }
}