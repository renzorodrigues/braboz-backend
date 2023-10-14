using System.Text.Json;
using Braboz.Core.Interfaces;
using Braboz.Core.Settings;

namespace Braboz.Infra.Services.HttpClient
{
    public class HttpClientFactory : IHttpClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly HttpClientSettings httpClientSettings;

        public HttpClientFactory(IHttpClientFactory httpClientFactory, HttpClientSettings httpClientSettings)
        {
            this.httpClientFactory = httpClientFactory;
            this.httpClientSettings = httpClientSettings;
        }

        public async Task<IEnumerable<T>> CreateClient<T>(HttpClientEnum httpClientEnum)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            var (baseAddress, requestUri) = this.GetSettings(httpClientEnum);

            var client = this.httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            try
            {
                var response = await client.GetStringAsync(requestUri);

                var serializedResponse = JsonSerializer.Deserialize<IEnumerable<T>>(response, options);

                return serializedResponse!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private (string baseAddress, string requestUri) GetSettings(HttpClientEnum httpClientEnum)
        {
            return httpClientEnum switch
            {
                HttpClientEnum.Users => (this.httpClientSettings.Users.BaseAddress, this.httpClientSettings.Users.RequestUri),
                _ => (string.Empty, string.Empty),
            };
        }
    }
}
