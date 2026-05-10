using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Models.Responses.Transactions
{
   

    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("valor")]
        public double? Valor { get; set; }

        [JsonProperty("tipo")]
        public int? Tipo { get; set; }

        [JsonProperty("categoriaId")]
        public string CategoriaId { get; set; }

        [JsonProperty("categoriaDescricao")]
        public string CategoriaDescricao { get; set; }

        [JsonProperty("pessoaId")]
        public string PessoaId { get; set; }

        [JsonProperty("pessoaNome")]
        public string PessoaNome { get; set; }

        [JsonProperty("data")]
        public DateTime? Data { get; set; }
    }

    public class AllTransactionsRes
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("totalCount")]
        public int? TotalCount { get; set; }

        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("pageSize")]
        public int? PageSize { get; set; }

        [JsonProperty("totalPages")]
        public int? TotalPages { get; set; }
    }




}
