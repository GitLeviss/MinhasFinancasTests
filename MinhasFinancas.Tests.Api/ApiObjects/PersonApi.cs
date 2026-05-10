using MinhasFinancas.Tests.Api.Endpoints;
using MinhasFinancas.Tests.Api.Http;
using MinhasFinancas.Tests.Api.Models.Requests.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.ApiObjects
{
    public class PersonApi : BaseApiObject
    {
        public PersonApi(ApiClient apiClient) : base(apiClient)
        {
        }
        public async Task<HttpResponseMessage> RegisterPersonAsync(PersonReq request)
        {
            return await ApiClient.PostAsync(ApiEndpoints.PersonEndpoint, request).ConfigureAwait(false);
        }
        public async Task<HttpResponseMessage> ConsultPersonByIdAsync(string request)
        {
            return await ApiClient.GetAsync(ApiEndpoints.PersonEndpoint + request).ConfigureAwait(false);
        }
        public async Task<HttpResponseMessage> UpdatePersonByIdAsync(string id, PersonReq request)
        {
            return await ApiClient.PutAsync(ApiEndpoints.PersonEndpoint, id, request).ConfigureAwait(false);
        }
        public async Task<HttpResponseMessage> DeletePersonByIdAsync(string id)
        {
            return await ApiClient.DeleteAsync(ApiEndpoints.PersonEndpoint + id).ConfigureAwait(false);
        }
    }
}
