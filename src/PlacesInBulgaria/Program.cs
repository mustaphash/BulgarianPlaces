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
                  (CategoryVerb opts) => new CategoryParser().ParseCategory(opts).GetAwaiter().GetResult(),
                  (NameVerb opts) => new NameParser().ParseName(opts).GetAwaiter().GetResult(),
                  (LongAndLatVerb opts) => ParseLongAndLat(opts, opts).GetAwaiter().GetResult(),
                  (IEnumerable<Error> errs) => ExceptionHandling(errs).GetAwaiter().GetResult());
        }
    }
}
