using MinhasFinancas.Tests.Api.Endpoints;
using MinhasFinancas.Tests.Api.Http;
using MinhasFinancas.Tests.Api.Models.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.ApiObjects
{
    public class CategoryApi : BaseApiObject
    {
        public CategoryApi(ApiClient apiClient) : base(apiClient)
        {
        }
        public async Task<HttpResponseMessage> RegisterCategoryAsync(CategoryReq request)
        {
            return await ApiClient.PostAsync(ApiEndpoints.CategoryEndpoint, request).ConfigureAwait(false);
        }
        public async Task<HttpResponseMessage> ConsultCategoryAsync(string request)
        {
            return await ApiClient.GetAsync(ApiEndpoints.CategoryEndpoint + request).ConfigureAwait(false);
        }
        public async Task<HttpResponseMessage> DeleteCategoryByIdAsync(string id)
        {
            return await ApiClient.DeleteAsync(ApiEndpoints.CategoryEndpoint + id).ConfigureAwait(false);
        }
    }
}
