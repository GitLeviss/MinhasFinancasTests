using MinhasFinancas.Tests.Api.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Tests
{
    [Collection("ApiCollection")] 
    public abstract class BaseTests
    {
        protected HttpClient HttpClient { get; private set; }
        protected ApiClient ApiClient { get; private set; }

        public BaseTests(ApiFixture fixture)
        {
            HttpClient = fixture.HttpClient;
            ApiClient = new ApiClient(HttpClient);
        }
    }
}
