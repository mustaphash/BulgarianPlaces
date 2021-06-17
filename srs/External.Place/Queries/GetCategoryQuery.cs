﻿using External.Places.Queries.Interfaces;
using Models.Place;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace External.Places.Queries
{
    class GetCategoryQuery
    {
        public class GetTownQuery : IGetCategoryQuery
        {
            private readonly Context _httpClientContext;

            public GetTownQuery()
                : this(new Context())
            {
            }

            public GetTownQuery(Context httpClientContext)
            {
                _httpClientContext = httpClientContext;
            }

            public async Task<Place> ExecuteAsync()
            {
                var httpClient = _httpClientContext.GetClient();
                HttpResponseMessage response = await httpClient.GetAsync($"http://62.171.141.18/?fbclid=IwAR3YE74zv_w-pN6hJNNq5_oljKj3821fsXgupggehcRF2gZ9SmQX72L3sME");
                string content = await response.Content.ReadAsStringAsync();

                var places = JsonConvert.DeserializeObject<Place>(content);

                return places;
            }

        }
    }
}
