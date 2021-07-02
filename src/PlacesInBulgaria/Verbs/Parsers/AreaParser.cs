using ConsoleTableExt;
using External.Places.Queries;
using External.Places.Queries.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace PlacesInBulgaria.Verbs.Parsers
{
    public class AreaParser
    {
        public async Task<int> Parse(AreaVerb verb)
        {
            IGetTownQuery townName = new GetTownQuery();
            var townLandmarks = await townName.ExecuteAsync(verb.Name);

            DataTable areaTable = new DataTable($"Забележителности за местоположение {townLandmarks}");

            areaTable.Columns.Add("Номер");
            areaTable.Columns.Add("Име");
            areaTable.Columns.Add("Географска дължина");
            areaTable.Columns.Add("Географска широчина");
            areaTable.Columns.Add("Категория");
            

            int i = 1;
            foreach (var townLandmark in townLandmarks)
            {
                areaTable.Rows.Add(
                    i,
                    townLandmark.Name,
                    townLandmark.Longitude,
                    townLandmark.Latitude,
                    townLandmark.Category);

                i++;
            }
            ConsoleTableBuilder
                .From(areaTable)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine();

            return 0;
        }
    }
}
