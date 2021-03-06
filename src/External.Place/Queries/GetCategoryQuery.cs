using External.Places.Queries.Interfaces;
using Models.Place;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace External.Places.Queries
{
    public class GetCategoryQuery : IGetCategoryQuery
    {
        private readonly Context _httpClientContext;

        public GetCategoryQuery()
            : this(new Context())
        {
        }

        public GetCategoryQuery(Context httpClientContext)
        {
            _httpClientContext = httpClientContext;
        }

        public async Task<List<Place>> ExecuteAsync(string category)
        {
            var httpClient = _httpClientContext.GetClient();
            HttpResponseMessage response = await httpClient.GetAsync($"http://62.171.141.18/?fbclid=IwAR3YE74zv_w-pN6hJNNq5_oljKj3821fsXgupggehcRF2gZ9SmQX72L3sME");
            string content = await response.Content.ReadAsStringAsync();

            var places = JsonConvert.DeserializeObject<List<Place>>(content);
            List<Place> categoryName = places.Where(p => p.Category.ToUpper().Contains(category.ToUpper())).ToList();

            return categoryName;
        }

    }
}

