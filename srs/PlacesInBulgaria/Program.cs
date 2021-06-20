using External.Places.Queries;
using External.Places.Queries.Interfaces;
using System;
using System.Threading.Tasks;

namespace PlacesInBulgaria
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("Търсене по:");
            Console.WriteLine("1-Област");
            Console.WriteLine("2-Категория");
            Console.WriteLine("3-Географска дължина и широчина");
            Console.WriteLine("4-Име");




            while (true)
            {
                Console.Write("Отговор: ");
                int number = int.Parse(Console.ReadLine());

                if (number == 1)
                {
                    string answer = Console.ReadLine();
                    IGetTownQuery townName = new GetTownQuery();
                    var townLandmarks = await townName.ExecuteAsync(answer);

                    foreach (var townLandmark in townLandmarks)
                    {
                        Console.WriteLine(townLandmark.Address);
                    }
                }
               // else if (number == 2)
               // {
               //     Console.Write("Напишете категория, моля: ");
               //     IGetCategoryQuery townCategory = new GetCategoryQuery();
               //     var category = await townCategory.ExecuteAsync();
               // }
               // else if (number == 3)
               // {
               //     IGetLngAndLatQuery townLongAndLat = new GetLongAndLatQuery();
               //     var longAndLat = await townLongAndLat.ExecuteAsync();
               //
               // }
               // else if (number == 4)
               // {
               //     IGetNameQuery townNames = new GetNameQuery();
               //     var names = await townNames.ExecuteAsync();
               // }

            }
        }
    }
}
