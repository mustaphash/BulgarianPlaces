using External.Places.Queries;
using External.Places.Queries.Interfaces;
using System;
using System.Threading.Tasks;

namespace PlacesInBulgaria.Verbs.Parsers
{
    public class AreaParser
    {
        public async Task<int> Parse(AreaVerb verb)
        {
            IGetTownQuery townName = new GetTownQuery();
            var townLandmarks = await townName.ExecuteAsync(verb.Name);

            foreach (var townLandmark in townLandmarks)
            {
                Console.WriteLine(townLandmark.Name);
                Console.WriteLine($"{townLandmark.Longitude} -- {townLandmark.Latitude}");
                Console.WriteLine(townLandmark.Category);
            }

            return 0;
        }
    }
}
