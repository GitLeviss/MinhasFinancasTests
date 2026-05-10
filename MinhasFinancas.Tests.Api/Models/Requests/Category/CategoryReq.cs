using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Models.Requests.Category
{
    public class CategoryReq
    {
        [JsonProperty("descricao")]
        public string Descricao { get; set; } = "Postman Despesa " + new Random().Next(0, 9999);

        [JsonProperty("finalidade")]
        public int? Finalidade { get; set; } = 0;
    }



}
