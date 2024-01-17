namespace ImplementHTTPCallRetries
{
    public class Test
    {
        private readonly HttpClient _httpClient;
        public Test(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> GetWeather()
        {
            try
            {
                var e = _httpClient.GetAsync("https://localhost:7135/api/Employee").Result;
                return e.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
