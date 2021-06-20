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
                    Console.Write("Напишете област, моля: ");
                    string answer = Console.ReadLine();
                    IGetTownQuery townName = new GetTownQuery();
                    var townLandmarks = await townName.ExecuteAsync(answer);

                    foreach (var townLandmark in townLandmarks)
                    {
                        Console.WriteLine(townLandmark.Name);
                        Console.WriteLine($"{townLandmark.Longitude} -- {townLandmark.Latitude}");
                        Console.WriteLine(townLandmark.Category);
                    }
                }
                else if (number == 2)
                {
                    Console.Write("Напишете категория, моля: ");
                    string answer = Console.ReadLine();
                    IGetCategoryQuery townCategory = new GetCategoryQuery();
                    var categoryNames = await townCategory.ExecuteAsync(answer);

                    foreach (var categoryName in categoryNames)
                    {
                        Console.WriteLine(categoryName.Address);
                        Console.WriteLine(categoryName.Name);
                        Console.WriteLine($"{categoryName.Longitude} -- {categoryName.Latitude}");
                    }
                }
                 else if (number == 3)
                 {
                    //42.51495588296913, 27.450042893768337
                    Console.Write("Географска дължина: ");
                    double answerLongi = double.Parse(Console.ReadLine());
                    Console.Write("Географска ширина: ");
                    double answerLat = double.Parse(Console.ReadLine()); 
                    IGetLngAndLatQuery townLongAndLat = new GetLongAndLatQuery();
                     var longAndLat = await townLongAndLat.ExecuteAsync(answerLongi,answerLat);

                    foreach (var longiLat in longAndLat)
                    {
                        Console.WriteLine(longiLat.Name);
                        Console.WriteLine(longiLat.Description);
                        Console.WriteLine(longiLat.Category);
                    }
                
                 }
                else if (number == 4)
                {
                    Console.WriteLine("Моле напишете името на местността: ");
                    string answer = Console.ReadLine();
                    IGetNameQuery townNames = new GetNameQuery();
                    var names = await townNames.ExecuteAsync(answer);

                    foreach (var name in names)
                    {
                        Console.WriteLine(name.Address);
                        Console.WriteLine(name.Description);
                    }
                }

            }
        }
    }
}
