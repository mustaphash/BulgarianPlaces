using ConsoleTableExt;
using External.Places.Queries;
using External.Places.Queries.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace PlacesInBulgaria.Verbs.Parsers
{
    public class CategoryParser
    {
        public async Task<int> ParseCategory(CategoryVerb category)
        {
            Console.WriteLine("Choosed category");

            IGetCategoryQuery townCategory = new GetCategoryQuery();
            var categoryNames = await townCategory.ExecuteAsync("история и култура");

            DataTable dataTable = new DataTable($"Забележителности за категория {categoryNames}");

            dataTable.Columns.Add("Номер");
            dataTable.Columns.Add("Име");
            dataTable.Columns.Add("Адрес");
            dataTable.Columns.Add("Географска дължина");
            dataTable.Columns.Add("Географска широчина");

            int i = 1;
            foreach (var categoryName in categoryNames)
            {
                dataTable.Rows.Add(
                    i,
                    categoryName.Name,
                    categoryName.Address,
                    categoryName.Latitude,
                    categoryName.Longitude);

                i++;
            }


            ConsoleTableBuilder
                .From(dataTable)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine();

            return 0;
        }
    }
}
