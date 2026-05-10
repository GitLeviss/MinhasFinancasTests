using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Models.Responses.Person
{
    public class PersonRes
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("dataNascimento")]
        public DateTime? DataNascimento { get; set; }

        [JsonProperty("idade")]
        public int? Idade { get; set; }
    }



}
