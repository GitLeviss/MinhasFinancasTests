using MinhasFinancas.Tests.Api.ApiObjects;
using MinhasFinancas.Tests.Api.Models.Requests.Transactions;
using MinhasFinancas.Tests.Api.Models.Responses;
using MinhasFinancas.Tests.Api.Models.Responses.Transactions;
using Newtonsoft.Json;
using System.Net;

namespace MinhasFinancas.Tests.Api.Tests
{
    public class TransactionTests : BaseTests
    {
        private readonly TransactionsApi _transactionsApi;
        private static string _categoryId { get; set; }


        public TransactionTests(ApiFixture fixture) : base(fixture)
        {
            _transactionsApi = new TransactionsApi(ApiClient);
        }

        [Fact]
        public async Task Should_Register_A_New_Transaction_With_Valid_data()
        {
            var payload = new TransactionsReq();
            var response = await _transactionsApi.RegisterTransactionAsync(payload);
            Validators.AssertThatStatusCodeIsSuccessful(response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            TransactionsRes? data = JsonConvert.DeserializeObject<TransactionsRes>(content);
            Assert.True(data != null, "Response body is not null");
            Validators.AssertThatIsEqualTo("Descrição", data.Descricao, payload.Descricao);
        }

        [Fact]
        public async Task Should_Consult_Transaction()
        {
            var response = await _transactionsApi.ConsultTransactionAsync("/019e0fd4-733b-7807-bc52-c3be866ae499");
            Validators.AssertThatStatusCodeIsSuccessful(response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            TransactionsRes? data = JsonConvert.DeserializeObject<TransactionsRes>(content);
            Assert.True(data != null, "Response body is not null");
        }

        [Fact]
        public async Task Should_Consult_All_Transactions()
        {
            var response = await _transactionsApi.ConsultTransactionAsync("?page=1&pageSize=10");
            Validators.AssertThatStatusCodeIsSuccessful(response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            AllCategoriesRes? data = JsonConvert.DeserializeObject<AllCategoriesRes>(content);
            Assert.True(data != null, "Response body is not null");
        }

        [Fact]
        public async Task Shouldt_Register_A_New_Transaction_When_Type_Is_Expense_And_Category_Is_Balance()
        {
            var payload = new TransactionsReq
            {
                CategoriaId = "019e0edd-6667-725f-85a8-6a293dcebfdf",
                Tipo = 2
            };
            var response = await _transactionsApi.RegisterTransactionAsync(payload);
            Validators.AssertThatStatusCodeIsEqualTo(response.StatusCode,HttpStatusCode.InternalServerError);
            var content = await response.Content.ReadAsStringAsync();
            ErrorTransactionRes? data = JsonConvert.DeserializeObject<ErrorTransactionRes>(content);
            Assert.True(data != null, "Response body is not null");
            Validators.AssertThatIsEqualToInt("Descrição", data.StatusCode, 500);
            Validators.AssertThatIsEqualTo("Message", data.Message, "Ocorreu um erro interno no servidor.");
            Validators.AssertThatIsEqualTo("Detailed", data.Detailed, "Não é possível registrar receita em categoria de despesa.");
        }
        [Fact]
        public async Task Shouldt_Register_A_New_Transaction_When_Person_Dont_Have_18_Years_Old()
        {
            var payload = new TransactionsReq
            {
                CategoriaId = "019e0edd-6667-77f0-aa01-501c19e38c71",
                PessoaId = "019e0edd-669f-77dc-b380-cc7b027fc767",
                Tipo = 1
            };
            var response = await _transactionsApi.RegisterTransactionAsync(payload);
            Validators.AssertThatStatusCodeIsEqualTo(response.StatusCode,HttpStatusCode.InternalServerError);
            var content = await response.Content.ReadAsStringAsync();
            ErrorTransactionRes? data = JsonConvert.DeserializeObject<ErrorTransactionRes>(content);
            Assert.True(data != null, "Response body is not null");
            Validators.AssertThatIsEqualToInt("Descrição", data.StatusCode, 500);
            Validators.AssertThatIsEqualTo("Message", data.Message, "Ocorreu um erro interno no servidor.");
            Validators.AssertThatIsEqualTo("Detailed", data.Detailed, "Menores de 18 anos não podem registrar receitas.");
        }
        [Fact]
        public async Task Shouldt_Register_A_New_Transaction_When_Type_Is_Balance_And_Category_Is_Expense()
        {
            var payload = new TransactionsReq
            {
                CategoriaId = "019e0edd-6667-77f0-aa01-501c19e38c71",
                Tipo = 0
            };
            var response = await _transactionsApi.RegisterTransactionAsync(payload);
            Validators.AssertThatStatusCodeIsEqualTo(response.StatusCode,HttpStatusCode.InternalServerError);
            var content = await response.Content.ReadAsStringAsync();
            ErrorTransactionRes? data = JsonConvert.DeserializeObject<ErrorTransactionRes>(content);
            Assert.True(data != null, "Response body is not null");
            Validators.AssertThatIsEqualToInt("Descrição", data.StatusCode, 500);
            Validators.AssertThatIsEqualTo("Message", data.Message, "Ocorreu um erro interno no servidor.");
            Validators.AssertThatIsEqualTo("Detailed", data.Detailed, "Não é possível registrar despesa em categoria de receita.");
        }


    }
}
