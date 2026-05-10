using MinhasFinancas.Tests.Api.ApiObjects;
using MinhasFinancas.Tests.Api.Models.Requests;
using MinhasFinancas.Tests.Api.Models.Requests.Person;
using MinhasFinancas.Tests.Api.Models.Responses.Person;
using Newtonsoft.Json;

namespace MinhasFinancas.Tests.Api.Tests
{
    public class PersonTests : BaseTests
    {
        private readonly PersonApi _personApi;
        private static string _personId { get; set; }


        public PersonTests(ApiFixture fixture) : base(fixture)
        {
            _personApi = new PersonApi(ApiClient);
        }

        [Fact]
        public async Task Should_Register_A_New_Person_With_Valid_data()
        {
            var payload = new PersonReq();
            var response = await _personApi.RegisterPersonAsync(payload);
            Validators.AssertThatStatusCodeIsSuccessful(response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            PersonRes? data = JsonConvert.DeserializeObject<PersonRes>(content);
            _personId = data.Id;
            Assert.True(data != null, "Response body is not null");
            Validators.AssertThatIsEqualTo("Id", data.Id, _personId);
            Validators.AssertThatIsEqualTo("Name", data.Nome, payload.Nome);
        }

        [Fact]
        public async Task Should_Consult_Registered_Person()
        {
            var response = await _personApi.ConsultPersonByIdAsync(_personId);
            Validators.AssertThatStatusCodeIsSuccessful(response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            PersonRes? data = JsonConvert.DeserializeObject<PersonRes>(content);
            _personId = data.Id;
            Assert.True(data != null, "Response body is not null");
            Validators.AssertThatIsEqualTo("Id", data.Id, _personId);
        }

        [Fact]
        public async Task Should_Update_Registered_Person()
        {
            var payload = new PersonReq
            {
                Nome = "User Name Edited "+ new Random().Next(0, 9999)
            };
            var response = await _personApi.UpdatePersonByIdAsync("/019e0edd-669f-7c7c-a3dd-e33654016103", payload);
            Validators.AssertThatStatusCodeIsSuccessful(response.StatusCode);
        }
        [Fact]
        public async Task Should_Delete_Registered_Person()
        {            
            var response = await _personApi.DeletePersonByIdAsync("/019e0edd-669f-7c7c-a3dd-e33654016103");
            Validators.AssertThatStatusCodeIsSuccessful(response.StatusCode);
        }

    }
}
