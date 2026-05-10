using MinhasFinancas.Tests.Api.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Http
{
    public class HttpClientFactory
    {
        public static HttpClient CreateClient()
        {
            var baseUrl = ApiEnvironmentConfig.Config.Base.Url.MinhasFinancas;
            var client = new HttpClient { BaseAddress = new Uri(baseUrl) };

            //client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
