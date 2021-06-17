using External.Places.Queries;
using External.Places.Queries.Interfaces;
using System;
using System.Device.Location;
using System.Linq;
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

            string answer;
            IGetTownQuery townName = new GetTownQuery();
            var town = await townName.ExecuteAsync();

            IGetCategoryQuery townCategory = new GetCategoryQuery();
            var category = await townCategory.ExecuteAsync();

            IGetLngAndLatQuery townLongAndLat = new GetLongAndLatQuery();
            var longAndLat = await townLongAndLat.ExecuteAsync();

            IGetNameQuery townNames = new GetNameQuery();
            var names = await townNames.ExecuteAsync();


           while (true)
           { 
            Console.Write("Отговор: ");
            int number = int.Parse(Console.ReadLine());
           
            if (number == 1)
            {
                Console.Write("Напишете област, моля: ");
                answer = Console.ReadLine();
                var filtredPlaces =await town.Where(p => p.Address.Contains(answer));
           
                foreach (var place in filtredPlaces)
                {
                    Console.Write($"{place.Name}");
                    Console.WriteLine();
                }
            }
            else if (number == 2)
            {
                Console.Write("Напишете категория, моля: ");
                answer = Console.ReadLine();
                var filtredCategory = places.Where(c => c.Category.Contains(answer));
           
                foreach (var category in filtredCategory)
                {
                    Console.WriteLine($"{category.Name}");
                }
            }
            else if (number == 3)
            {
                // 42.72292889087154, 23.248363872647936
                var latitude = 42.72292889087154; //double.Parse(Console.ReadLine());
                var longitude = 23.248363872647936; //double.Parse(Console.ReadLine());
                var coord = new GeoCoordinate(latitude, longitude);
           
                var nearest = places.Select(x =>
                new
                {
                    Place = x,
                    Location = new GeoCoordinate(x.Latitude, x.Longitude)
                })
                    .OrderBy(x => x.Location.GetDistanceTo(coord))
                    .First();
           
                Console.WriteLine(nearest.Place.Name);
                Console.WriteLine(nearest.Place.Description);
                Console.WriteLine(nearest.Place.Address);
           
           
            }
            else if (number == 4)
            {
                Console.Write("Напишете името на местността: ");
                answer = Console.ReadLine();
                var filtredName = places.Where(n => n.Name.Contains(answer));
                foreach (var name in filtredName)
                {
                    Console.WriteLine(name.Description);
                }
            }

            }
        }
    }
}
