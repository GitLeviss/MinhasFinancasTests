
using MinhasFinancas.Tests.Api.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Http
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            return await _httpClient.SendAsync(request);
        }
        public async Task<HttpResponseMessage> PostAsync(string endpoint, object body)
        {
            var jsonBody = JsonConvert.SerializeObject(body);

            using var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };

            return await _httpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> PutAsync(string endpoint,string id, object body)
        {
            var jsonBody = JsonConvert.SerializeObject(body);

            using var request = new HttpRequestMessage(HttpMethod.Put, endpoint + id)
            {
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };

            return await _httpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
            return await _httpClient.SendAsync(request);
        }


    }
}
