using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            Console.WriteLine("Search by:");
            Console.WriteLine("1-Town");
            Console.WriteLine("2-Category");
            Console.WriteLine("3-Longitude and latitude");

            string answer;
            int number = int.Parse(Console.ReadLine());

            if (number == 1)
            {
                answer = Console.ReadLine();
            }

            foreach (var place in places)
            {
                Console.Write($"{place.Address} - ");
                Console.Write(place.Latitude);
                Console.WriteLine();
            }
        }
    }
}
