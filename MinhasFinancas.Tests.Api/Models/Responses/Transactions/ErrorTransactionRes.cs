using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Models.Responses.Transactions
{
    public class ErrorTransactionRes
    {
        [JsonProperty("StatusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Detailed")]
        public string Detailed { get; set; }
    }


}
