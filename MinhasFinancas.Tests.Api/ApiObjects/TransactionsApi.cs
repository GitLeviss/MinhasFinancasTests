using MinhasFinancas.Tests.Api.Endpoints;
using MinhasFinancas.Tests.Api.Http;
using MinhasFinancas.Tests.Api.Models.Requests.Category;
using MinhasFinancas.Tests.Api.Models.Requests.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.ApiObjects
{
    public class TransactionsApi : BaseApiObject
    {
        public TransactionsApi(ApiClient apiClient) : base(apiClient)
        {
        }
        public async Task<HttpResponseMessage> RegisterTransactionAsync(TransactionsReq request)
        {
            return await ApiClient.PostAsync(ApiEndpoints.TransactionEndpoint, request).ConfigureAwait(false);
        }
        public async Task<HttpResponseMessage> ConsultTransactionAsync(string request)
        {
            return await ApiClient.GetAsync(ApiEndpoints.TransactionEndpoint + request).ConfigureAwait(false);
        }
        public async Task<HttpResponseMessage> DeleteTransactionByIdAsync(string id)
        {
            return await ApiClient.DeleteAsync(ApiEndpoints.TransactionEndpoint + id).ConfigureAwait(false);
        }
    }
}
