using MinhasFinancas.Tests.Api.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Tests
{

    public class ApiFixture : IDisposable
    {
        public HttpClient HttpClient { get; private set; }

        public ApiFixture()
        {
            InitializeAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeAsync()
        {
            try
            {
                HttpClient = HttpClientFactory.CreateClient();
            }
            catch (Exception ex)
            {
                throw new Exception($"Critical error in test setup: {ex.Message}", ex);
            }
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }

    [CollectionDefinition("ApiCollection")]
    public class ApiCollection : ICollectionFixture<ApiFixture>
    {

    }
}