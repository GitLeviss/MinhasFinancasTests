using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Models.Requests.Transactions
{

    public class TransactionsReq
    {
        [JsonProperty("categoriaId")]
        public string CategoriaId { get; set; } = "019e0edd-6667-725f-85a8-6a293dcebfdf";

        [JsonProperty("data")]
        public DateTime? Data { get; set; } = DateTime.Now.Date;

        [JsonProperty("descricao")]
        public string Descricao { get; set; } = "validar ambas";

        [JsonProperty("pessoaId")]
        public string PessoaId { get; set; } = "019e0edd-669f-757a-add6-40f987701af4";

        [JsonProperty("tipo")]
        public int? Tipo { get; set; } = 0;

        [JsonProperty("valor")]
        public double? Valor { get; set; } = 200.00;
    }


}
