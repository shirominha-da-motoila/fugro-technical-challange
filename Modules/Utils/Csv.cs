using System.Globalization;
using CsvHelper;

namespace Modules.Utils;

public static class Csv
{
    public static IEnumerable<T> ParseFromStream<T>(this Stream stream)
    {
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<T>().ToList();
        }
    }
}
