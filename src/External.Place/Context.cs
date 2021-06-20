using System.Net.Http;

namespace External.Places
{
    public class Context
    {
        private readonly HttpClient _httpClient;

        public Context()
            : this(new HttpClient())
        {

        }

        public Context(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpClient GetClient()
        {
            return _httpClient;
        }
    }
}
