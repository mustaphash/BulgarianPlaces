using CommandLine;
using External.Places.Queries;
using External.Places.Queries.Interfaces;
using PlacesInBulgaria.Verbs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacesInBulgaria
{
    class Program
    {
        static async Task<int> ParseArea(AreaVerb area)
        {
            IGetTownQuery townName = new GetTownQuery();
            var townLandmarks = await townName.ExecuteAsync(area.Name);

            foreach (var townLandmark in townLandmarks)
            {
                Console.WriteLine(townLandmark.Name);
                Console.WriteLine($"{townLandmark.Longitude} -- {townLandmark.Latitude}");
                Console.WriteLine(townLandmark.Category);
            }
            return 0;
        }

        static async Task<int> ParseCategory(CategoryVerb category)
        {
            Console.WriteLine("Choosed category");

            IGetCategoryQuery townCategory = new GetCategoryQuery();
            var categoryNames = await townCategory.ExecuteAsync(category.Name);

            foreach (var categoryName in categoryNames)
            {
                Console.WriteLine(categoryName.Address);
                Console.WriteLine(categoryName.Name);
                Console.WriteLine($"{categoryName.Longitude} -- {categoryName.Latitude}");
            }
            return 0;
        }
        static async Task<int> ParseLongAndLAt(LongAndLatVerb longitude, LongAndLatVerb latitude)
        {
            IGetLngAndLatQuery townLongAndLat = new GetLongAndLatQuery();
            var longAndLat = await townLongAndLat.ExecuteAsync(longitude.Longitude, latitude.Latitude);

            foreach (var longiLat in longAndLat)
            {
                Console.WriteLine(longiLat.Name);
                Console.WriteLine(longiLat.Description);
                Console.WriteLine(longiLat.Category);
            }
            return 0;
        }

        static async Task<int> ParseName(NameVerb nameA)
        {

            IGetNameQuery townNames = new GetNameQuery();
            var names = await townNames.ExecuteAsync(nameA.Name);

            foreach (var name in names)
            {
                Console.WriteLine(name.Address);
                Console.WriteLine(name.Description);
            }
            return 0;
        }

        static Task<int> ExceptionHandling(IEnumerable<Error> errors)
        {
            Console.WriteLine("Something went wrong.");
            return Task.FromResult(0);
        }

        static async Task Main(string[] args)
        {
            Parser.Default.ParseArguments<AreaVerb, CategoryVerb>(args)
                .MapResult(
                  (AreaVerb opts) => ParseArea(opts).GetAwaiter().GetResult(),
                  (CategoryVerb opts) => ParseCategory(opts).GetAwaiter().GetResult(),
                  (NameVerb opts) => ParseName(opts).GetAwaiter().GetResult(),
                  (IEnumerable<Error> errs) => ExceptionHandling(errs).GetAwaiter().GetResult());

            //Console.WriteLine("Търсене по:");
            //Console.WriteLine("1-Област");
            //Console.WriteLine("2-Категория");
            //Console.WriteLine("3-Географска дължина и широчина");
            //Console.WriteLine("4-Име");

            //while (true)
            //{

            //    }

            //    }
            //    else if (number == 3)
            //    {
            //        //42.51495588296913, 27.450042893768337
            //        Console.Write("Географска дължина: ");
            //        double answerLongi = double.Parse(Console.ReadLine());
            //        Console.Write("Географска ширина: ");
            //        double answerLat = double.Parse(Console.ReadLine());
            //        IGetLngAndLatQuery townLongAndLat = new GetLongAndLatQuery();
            //        var longAndLat = await townLongAndLat.ExecuteAsync(answerLongi, answerLat);

            //        foreach (var longiLat in longAndLat)
            //        {
            //            Console.WriteLine(longiLat.Name);
            //            Console.WriteLine(longiLat.Description);
            //            Console.WriteLine(longiLat.Category);
            //        }

            //    }
            //    else if (number == 4)
            //    {
            //        Console.WriteLine("Моле напишете името на местността: ");
            //        string answer = Console.ReadLine();
            //        IGetNameQuery townNames = new GetNameQuery();
            //        var names = await townNames.ExecuteAsync(answer);

            //        foreach (var name in names)
            //        {
            //            Console.WriteLine(name.Address);
            //            Console.WriteLine(name.Description);
            //        }
            //    }
            //}
        }
    }
}
