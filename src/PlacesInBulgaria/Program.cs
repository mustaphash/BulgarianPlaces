using CommandLine;
using ConsoleTableExt;
using External.Places.Queries;
using External.Places.Queries.Interfaces;
using PlacesInBulgaria.Verbs;
using PlacesInBulgaria.Verbs.Parsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PlacesInBulgaria
{
    class Program
    {
        static async Task<int> ParseCategory(CategoryVerb category)
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

        static async Task<int> ParseLongAndLat(LongAndLatVerb longitude, LongAndLatVerb latitude)
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

        static async Task<int> ParseName(NameVerb nameA)
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

        static Task<int> ExceptionHandling(IEnumerable<Error> errors)
        {
            Console.WriteLine("Something went wrong.");
            return Task.FromResult(0);
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<AreaVerb, CategoryVerb, NameVerb,LongAndLatVerb>(args)
                .MapResult(
                  (AreaVerb opts) => new AreaParser().Parse(opts).GetAwaiter().GetResult(),
                  (CategoryVerb opts) => ParseCategory(opts).GetAwaiter().GetResult(),
                  (NameVerb opts) => ParseName(opts).GetAwaiter().GetResult(),
                  (LongAndLatVerb opts) => ParseLongAndLat(opts, opts).GetAwaiter().GetResult(),
                  (IEnumerable<Error> errs) => ExceptionHandling(errs).GetAwaiter().GetResult());
        }
    }
}
