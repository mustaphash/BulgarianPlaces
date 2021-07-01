using ConsoleTableExt;
using External.Places.Queries;
using External.Places.Queries.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace PlacesInBulgaria.Verbs.Parsers
{
    public class NameParser
    {
        public async Task<int> ParseName(NameVerb nameA)
        {
            IGetNameQuery townNames = new GetNameQuery();
            var names = await townNames.ExecuteAsync(nameA.Name);

            DataTable NameTable = new DataTable($"Забележителности за име {names}");

            NameTable.Columns.Add("Номер");
            NameTable.Columns.Add("Адрес");
            NameTable.Columns.Add("Описание");

            int i = 1;
            foreach (var name in names)
            {
                NameTable.Rows.Add(
                    i,
                    name.Address,
                    name.Description);

                i++;
            }
            ConsoleTableBuilder
                .From(NameTable)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine();

            return 0;
        }
    }
}
