using External.Places.Queries.Interfaces;
using Models.Place;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace External.Places.Queries
{
    public class GetLongAndLatQuery : IGetLngAndLatQuery
    {

        private readonly Context _httpClientContext;

        public GetLongAndLatQuery()
            : this(new Context())
        {
        }

        public GetLongAndLatQuery(Context httpClientContext)
        {
            _httpClientContext = httpClientContext;
        }

        public async Task<List<Place>> ExecuteAsync(double longitude, double latitude)
        {
            var httpClient = _httpClientContext.GetClient();
            HttpResponseMessage response = await httpClient.GetAsync($"http://62.171.141.18/?fbclid=IwAR3YE74zv_w-pN6hJNNq5_oljKj3821fsXgupggehcRF2gZ9SmQX72L3sME");
            string content = await response.Content.ReadAsStringAsync();

            var places = JsonConvert.DeserializeObject<List<Place>>(content);
            List<Place> longiLatitude = places.Where(p => p.Longitude.Equals(longitude)).Where(l=>l.Latitude.Equals(latitude)).ToList();


            return longiLatitude;
        }


    }
}
