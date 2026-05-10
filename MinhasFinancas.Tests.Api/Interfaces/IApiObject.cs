using MinhasFinancas.Tests.Api.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Interfaces
{
    public interface IApiObject
    {
        ApiClient ApiClient { get; }
    }
}
