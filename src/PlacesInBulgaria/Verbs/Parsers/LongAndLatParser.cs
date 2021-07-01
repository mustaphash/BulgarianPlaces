using ConsoleTableExt;
using External.Places.Queries;
using External.Places.Queries.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace PlacesInBulgaria.Verbs.Parsers
{
    class LongAndLatParser
    {
        public async Task<int> ParseLongAndLat(LongAndLatVerb longitude, LongAndLatVerb latitude)
        {
            IGetLngAndLatQuery townLongAndLat = new GetLongAndLatQuery();
            var longAndLat = await townLongAndLat.ExecuteAsync(longitude.Longitude, latitude.Latitude);

            DataTable longLatTable = new DataTable($"Забележителности за географска дължина и широчина {longAndLat}");

            longLatTable.Columns.Add("Номер");
            longLatTable.Columns.Add("Име");
            longLatTable.Columns.Add("Описание");
            longLatTable.Columns.Add("Категория");

            int i = 1;
            foreach (var longiLat in longAndLat)
            {
                longLatTable.Rows.Add(
                    i,
                    longiLat.Name,
                    longiLat.Description,
                    longiLat.Category);

                i++;
            }

            ConsoleTableBuilder
                .From(longLatTable)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine();

            return 0;
        }
    }
}
