using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlacesInBulgaria
{
    class Program
    {

        static async Task Main(string[] args)
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"http://62.171.141.18/?fbclid=IwAR3YE74zv_w-pN6hJNNq5_oljKj3821fsXgupggehcRF2gZ9SmQX72L3sME");
            string content = await response.Content.ReadAsStringAsync();


            var places = JsonConvert.DeserializeObject<List<Place>>(content);


            Console.WriteLine("Търсене по:");
            Console.WriteLine("1-Област");
            Console.WriteLine("2-Категория");
            Console.WriteLine("3-Географска дължина и широчина");
            Console.WriteLine("4-Име");

            string answer;


            while (true)
            {
                Console.Write("Отговор: ");
                int number = int.Parse(Console.ReadLine());


                if (number == 1)
                {
                    Console.Write("Напишете област, моля: ");
                    answer = Console.ReadLine();
                    var filtredPlaces = places.Where(p => p.Address.Contains(answer));

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
