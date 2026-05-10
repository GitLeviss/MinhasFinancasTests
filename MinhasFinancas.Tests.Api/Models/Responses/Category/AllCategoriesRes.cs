using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Models.Responses
{

    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("finalidade")]
        public int? Finalidade { get; set; }
    }

    public class AllCategoriesRes
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
