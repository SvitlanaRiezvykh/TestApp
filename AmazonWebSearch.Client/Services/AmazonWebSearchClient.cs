using AmazonWebSearch.Contracts;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AmazonWebSearch.Client.Services
{
    public class AmazonWebSearchClient : IAmazonSearch
    {
        private readonly Uri _hostUri;
        private readonly HttpClient _client;

        public AmazonWebSearchClient(string hostUri)
        {
            _hostUri = new Uri(hostUri);
            _client = new HttpClient();
        }

        public AmazonWebSearchClient(string hostUri, HttpClient client)
        {
            _hostUri = new Uri(hostUri);
            _client = client;
        }

        public async Task<double> FindPrice(string productCatgoty, string deliveryCountry)
        {
            var findPriceUri = new Uri(_hostUri, "AmazonSearch/FindPrice");

            var request = new PriceSearchRequest
            {
                ProductCatgoty = productCatgoty,
                DeliveryCountry = deliveryCountry,
            };

            return await RequestResultWithPost<double, PriceSearchRequest>(findPriceUri, request);
        }
        private async Task<T> RequestResultWithPost<T, C>(Uri uri, C content)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync(uri, content);
            }
            catch (HttpRequestException ex)
            {
                // todo log exception ex
                return default(T);
            }
            //if (!response.IsSuccessStatusCode) todo wotk with exception;

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseBody);

            return result;
        }
    }
}