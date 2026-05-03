using CsvHelper;
using System.Globalization;
using System.Text;
using VideoGameManager.Models;

namespace VideoGameManager.Services
{
    public class GamesExporter
    {
        public byte[] ExportToCsv(List<Game> games)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream, Encoding.UTF8))
                {
                    using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvWriter.WriteRecords(games);
                    }
                }

                return memoryStream.ToArray();
            }
        }
    }
}
