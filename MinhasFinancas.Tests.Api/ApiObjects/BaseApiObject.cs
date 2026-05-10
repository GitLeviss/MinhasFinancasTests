using MinhasFinancas.Tests.Api.Http;
using MinhasFinancas.Tests.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.ApiObjects
{
    public abstract class BaseApiObject : IApiObject
    {
        public ApiClient ApiClient { get; }

        protected BaseApiObject(ApiClient apiClient)
        {
            ApiClient = apiClient
                ?? throw new ArgumentNullException(nameof(apiClient), "ApiClient cannot be null");
        }
    }
}
