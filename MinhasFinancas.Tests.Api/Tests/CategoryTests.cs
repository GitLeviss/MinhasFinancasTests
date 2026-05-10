using MinhasFinancas.Tests.Api.ApiObjects;
using MinhasFinancas.Tests.Api.Models.Requests;
using MinhasFinancas.Tests.Api.Models.Requests.Category;
using MinhasFinancas.Tests.Api.Models.Responses;
using MinhasFinancas.Tests.Api.Models.Responses.Category;
using Newtonsoft.Json;

namespace MinhasFinancas.Tests.Api.Tests
{
    public class CategoryTests : BaseTests
    {
        private readonly CategoryApi _categoryApi;
        private static string _categoryId { get; set; }


        public CategoryTests(ApiFixture fixture) : base(fixture)
        {
            _categoryApi = new CategoryApi(ApiClient);
        }

        [Fact]
        public async Task Should_Register_A_New_Category_With_Valid_data()
        {
            var payload = new CategoryReq();
            var response = await _categoryApi.RegisterCategoryAsync(payload);
            Validators.AssertThatStatusCodeIsSuccessful(response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            CategoryRes? data = JsonConvert.DeserializeObject<CategoryRes>(content);
            _categoryId = data.Id;
            Assert.True(data != null, "Response body is not null");
            Validators.AssertThatIsEqualTo("Descrição", data.Descricao, payload.Descricao);
        }

        [Fact]
        public async Task Should_Consult_Category()
        {
            var response = await _categoryApi.ConsultCategoryAsync(_categoryId);
            Validators.AssertThatStatusCodeIsSuccessful(response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            CategoryRes? data = JsonConvert.DeserializeObject<CategoryRes>(content);
            _categoryId = data.Id;
            Assert.True(data != null, "Response body is not null");
            Validators.AssertThatIsEqualTo("Id", data.Id, _categoryId);
        } 
        [Fact]
        public async Task Should_Consult_All_Categories()
        {
            var response = await _categoryApi.ConsultCategoryAsync("?page=1&pageSize=10");
            Validators.AssertThatStatusCodeIsSuccessful(response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            AllCategoriesRes? data = JsonConvert.DeserializeObject<AllCategoriesRes>(content);
            Assert.True(data != null, "Response body is not null");
        } 

    }
}
