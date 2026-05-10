using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Models.Requests.Person
{
    public class PersonReq
    {
        [JsonProperty("dataNascimento")]
        public string DataNascimento { get; set; } = "2003-11-01";

        [JsonProperty("nome")]
        public string Nome { get; set; } = "User Test " + new Random().Next(0, 9999);
    }


}
